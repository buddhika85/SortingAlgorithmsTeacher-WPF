# SortingAlgorithmsTeacher-WPF
This application allows the user to analyze/learn how sorting algorithms work.

1. The first user interface will allow the user to select a Sorting algorithm.

   ![Main](https://github.com/buddhika85/SortingAlgorithmsTeacher-WPF/blob/main/planning/UIs/1%20Main%20view.png?raw=true)

2. After the user selects a sorting algorithm (for example Bubble Sort), the user will be directed to the Algorithm Details Window. It looks like below,

   ![Algorithm Details View](https://github.com/buddhika85/SortingAlgorithmsTeacher-WPF/blob/main/planning/UIs/2%20Algorithm%20Details%20View.png?raw=true)

This window allows the user to view a demonstration of the sorting algorithm using a bar chart or a visual array. More details about the functionality of this window are explained in the below diagram.

   ![Algorithm Details View](https://github.com/buddhika85/SortingAlgorithmsTeacher-WPF/blob/main/planning/UIs/2.1%20Algorithm%20Details%20View-Annotated.png?raw=true)

3. Users can view more information about the sorting algorithm steps by analyzing the Log messages window.

   ![Log Messages View](https://github.com/buddhika85/SortingAlgorithmsTeacher-WPF/blob/main/planning/UIs/3.2LogMessages-Annoated.png?raw=true)
   
# Development Status

2023-10-13 - Version 1 is complete. This version includes visualizations for,
Bubble Sort
Selection Sort
Insertion Sort

Current Development - Version 2 will include,

Merge Sort 
Quick Sort


* Built with WPF on .NET 6
* C#
* XAML
* Uses MVVM
* INotifyPropertyChanged interface
* ICommand interface
* IValueConverter interface
* ObseravableCollection<T> 
* Data Access - on a .json data source
