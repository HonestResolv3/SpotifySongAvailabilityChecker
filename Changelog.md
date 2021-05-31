# Changelog

# v1 (Ending at [this](https://github.com/CasualHonest/SpotifySongAvailabilityChecker/commit/68be80e90d23cccdda9e4114e1b29068236a73ea) commit):
- [Program] - Initial release

# v2 (Ending at [this](https://github.com/CasualHonest/SpotifySongAvailabilityChecker/commit/14a6e73dcfdf44b346047948bafd15298b21cc06) commit):
Added:
- [Main UI] - Song/Album Search History.
- [Main UI] - Album Copyright Information.

Changed
- [Main UI] - Like items are grouped in boxes.
- [Main UI] - Availability & the new Search History use a new List View instead of a List Box.

Fixed
- [Main UI] - Indexes for controls in the Windows Form

# v2.5 (Ending at [this](https://github.com/CasualHonest/SpotifySongAvailabilityChecker/commit/9108c52d33442b4ce64d08ec9e1af17c30fa079a) commit):
Added:
- [Main UI] - Favorite entries in Search History.
- [Main UI] - Clear input button for song and album links.
- [Main UI] - Program errors box for most caught errors.
- [Main UI] - Settings area added.
- [Main UI / Settings] - Program resizing option.
- [Main UI / Settings] - Program search auto-switch option.
- [Main UI / Settings] - List grid lines option.
- [Main UI / Settings] - Default sort order option (Experimental).
- [Settings] - Input and new settings toggles will save on close.

Changed:
- [API] - RegionInfo replaced with RESTCountries-NET for country information.
- [Back-end] - .JSON reading and writing is improved to make it proper.
- [Main UI] - Adjusted size of the entire program including list views.
- [Main UI] - No results for a search entry will display a message box saying so.

Fixed:
- [Main UI] - Drop down boxes for search filters are now read-only.

# v3:
Added:
- [Back-end] - Country information caching/storing.
- [Main UI] - Splash screen before the program opens.
- [Main UI] - Number of countries a song is and isn't available in.
- [Main UI] - Clear search history button.
- [Main UI / Filters] - Added unavailability filter.
- [Main UI / Filters] - Added unavailability by country code filter.
- [Main UI / Filters] - Added unavailability by country name filter.
- [Main UI / Searching] - Message box when there's no results for a search.
- [Main UI / Settings] - Clearing both song and album input at the same time option added.
- [Settings] - Filter selection saves on close.

Changed:
- [Back-end] - Program can no longer run more than one instance at a time.
- [Back-end] - Country loading and search history code moved to the splash screen.
- [Back-end] - Removed variable assignments and used static references for List<> objects.
- [Main UI] - Window / Form size adjusted.

Fixed:
- [Main UI] - Searching a song or album that has no available markets disables searching until a new search is performed.
- [Main UI] - Searching for availability can no longer be done when the program first loads as nothing is displayed.
- [Main UI] - Searching for search history can no longer be done if there's no search history.
