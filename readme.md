# NotSupportedException when removing element from a Grid using TouchEffect.Command

Removing models from an `ObservableCollection` in the viewmodel, crashes the application in some cases when using `TouchEffect.Command`. I can remove any random items from the collection except the very same which fired the delete command itself.

See [GridPage.xaml](https://github.com/robotjatek/XamarinGridBugRepro/blob/master/XamarinGridBug/XamarinGridBug/Pages/GridPage.xaml) in my [Repository](https://github.com/robotjatek/XamarinGridBugRepro)

`ListView` is working with both renderers.

`Grid` is working with `buttons` when using the legacy renderers, but crashes when using fast renderers. (See screenshot of the exception).

There are no problems with Grid&Button combo if I use the native `Command` and `CommandParameter` options. (Both renderers.)

`BoxView` crashes when used in  `grid` with or without the `UseLegacyRenderers` flag when removed from the grid. But works fine in the `listview` with both renderers.

|	        | Button with xct | Button with native commands | BoxView | Label |
|:----|:------------:| :------------------------: | :----: | ------ |
| Grid fast renderer      |:x:|:heavy_check_mark:|:x:|:x:|
| Grid legacy renderer |:heavy_check_mark:|:heavy_check_mark:|:x:|:heavy_check_mark:|
| ListView fast renderer   |:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:| :heavy_check_mark: |
| ListView legacy renderer |:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|:heavy_check_mark:|

I tried to wrap my components inside a stack layout and binded my commands to the stacklayout itself, but its yielded the same result. Even an empty stacklayout crashes the app when used in grid with `TouchEvents`.

What curious is that I can remove any other random element from the `ObservableCollection` it wont crash the app up until that point where the firing element is removed from the grid. See  `RemoveLastCommand` in the [modelview](https://github.com/robotjatek/XamarinGridBugRepro/blob/master/XamarinGridBug/XamarinGridBug/ViewModel.cs) or the [GridRemoveLast](https://github.com/robotjatek/XamarinGridBugRepro/blob/master/XamarinGridBug/XamarinGridBug/Pages/GridRemoveLast.xaml) tab in the app. I'm not even sure if this is a Xamarin or XCT bug or something is fundamentaly wrong in my implementation, but the fact that the button control acts differently with and without XCT tells me that it is an XCT bug. Apologies if I'm wrong.

![xamarin_boxview_legacy](https://user-images.githubusercontent.com/5225221/136858763-2c168a06-c8e0-4689-a154-4b61aa72f5fc.png)
![xamarin_button_fast_renderer](https://user-images.githubusercontent.com/5225221/136858766-2506d309-4f90-4829-aa8d-cdf102415b00.png)
![xamarin_stack_layout_fast](https://user-images.githubusercontent.com/5225221/136858768-33c6c2ce-d744-40fd-8022-5c8b39c1dffe.png)
