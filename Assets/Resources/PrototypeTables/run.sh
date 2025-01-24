#!/bin/bash

# Remove the Main directory if it exists
rm -rf Main
dotnet new console --force -o Main

# Collect arguments starting from the second one
args=""
for arg in "${@:2}"; do
    args="$args $arg"
done

# Copy the first argument (assumed to be a file) to Main/Program.cs
cp "$1" "Main/Program.cs"
cd Main

# Run the dotnet application with the collected arguments
dotnet run -- $args

# Return to the previous directory
cd ..
rm -rf Main
