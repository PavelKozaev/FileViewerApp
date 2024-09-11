# FileViewerApp

## Overview
The File Viewer App is a Windows Forms application designed to load, display, and filter data from JSON and XML files. It allows users to view file metadata, read data into a DataGridView, and apply filters based on specific criteria. The application supports both JSON and XML formats, making it versatile for various data sources.

## Features
- Load and display file metadata (name, size, creation date).
- Parse and display data from JSON and XML files.
- Filter data by name or age.
- Display the first and last elements in the data set.
- Handle parsing errors and provide user feedback.

## File Formats

### JSON
The JSON file should be an array of objects with the following structure:
```json
[
  {
    "name": "Peter Petrov",
    "age": 30,
    "phone": "89502361271"
  },
  ...
]