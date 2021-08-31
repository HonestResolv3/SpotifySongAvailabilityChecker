using Newtonsoft.Json;
using RESTCountries.Models;
using RESTCountries.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SpotifySongAvailabilityChecker
{
    public partial class Startup : Form
    {
        public static List<string> errors = new List<string>();
        public static List<string> countryAvailability = new List<string>();
        public static List<string> countryNameAvailability = new List<string>();
        public static List<Country> countries;
        public static List<SearchObject> searches = new List<SearchObject>();
        public static List<ListViewItem> items = new List<ListViewItem>();

        readonly static string locationForSSACContent = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SSAC_Storage");

        public Startup()
        {
            InitializeComponent();
        }

        private async void Startup_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(Path.Combine(locationForSSACContent, "CountryCache.json")))
                    File.Create(Path.Combine(locationForSSACContent, "CountryCache.json"));
                else
                {
                    string cache = File.ReadAllText(Path.Combine(locationForSSACContent, "CountryCache.json"));
                    if (!string.IsNullOrWhiteSpace(cache))
                    {
                        countries = JsonConvert.DeserializeObject<List<Country>>(cache).ToList();
                        if (countries != null)
                        {
                            foreach (Country c in countries)
                            {
                                countryAvailability.Add(c.Alpha2Code);
                                countryNameAvailability.Add(c.Name);
                            }
                            Text = "Spotify Song Availability Checker";
                        }
                    }
                }
            }
            catch (IOException io)
            {
                errors.Add($"[{DateTime.Now.ToString("HH:mm:ss tt")}] There was an error trying to create or read the country cache file{Environment.NewLine}" +
                      $"Error: {io}{Environment.NewLine}{Environment.NewLine}");

            }
            catch (UnauthorizedAccessException ua)
            {
                errors.Add($"[{DateTime.Now.ToString("HH:mm:ss tt")}] There was an error trying to access the country cache file{Environment.NewLine}" +
                    $"Error: {ua}{Environment.NewLine}{Environment.NewLine}");
            }

            try
            {
                if (countries == null)
                {
                    countries = await RESTCountriesAPI.GetAllCountriesAsync();
                    foreach (Country c in countries)
                    {
                        countryAvailability.Add(c.Alpha2Code);
                        countryNameAvailability.Add(c.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                errors.Add($"[{DateTime.Now.ToString("HH:mm:ss tt")}] There was an error trying to get the countries to cache{Environment.NewLine}" +
                    $"Error: {ex}{Environment.NewLine}{Environment.NewLine}");
            }

            try
            {
                if (File.Exists(Path.Combine(locationForSSACContent, "SearchHistory.json")))
                    searches = JsonConvert.DeserializeObject<List<SearchObject>>(File.ReadAllText(Path.Combine(locationForSSACContent, "SearchHistory.json")));
                else
                    searches = new List<SearchObject>();

                if (searches == null)
                    searches = new List<SearchObject>();
            }
            catch
            {
                errors.Add($"[{DateTime.Now.ToString("HH:mm:ss tt")}] The search history file is not in the right format, attempting to delete{Environment.NewLine}{Environment.NewLine}");
                try
                {
                    File.Delete(Path.Combine(locationForSSACContent, "SearchHistory.json"));
                }
                catch (Exception ex)
                {
                    errors.Add($"[{DateTime.Now.ToString("HH:mm:ss tt")}] There was an error trying to delete the search history file{Environment.NewLine}" +
                        $"Error: {ex}{Environment.NewLine}{Environment.NewLine}");
                }
            }

            VerifyStoragePath();

            if (searches != null)
            {
                foreach (SearchObject obj in searches)
                {
                    ListViewItem item = new ListViewItem(new string[] { obj.GetFavoriteUnicode(), obj.Title, obj.Author, obj.Type.ToString(), obj.GetCorrectLink() });
                    items.Add(item);
                }
            }

            SSAC form = new SSAC();
            Hide();
            form.ShowDialog();
            Close();
        }


        public static void VerifyStoragePath()
        {
            if (!Directory.Exists(locationForSSACContent))
                _ = Directory.CreateDirectory(locationForSSACContent);

            if (!File.Exists(Path.Combine(locationForSSACContent, "SearchHistory.json")))
                _ = File.Create(Path.Combine(locationForSSACContent, "SearchHistory.json"));
        }
    }
}
