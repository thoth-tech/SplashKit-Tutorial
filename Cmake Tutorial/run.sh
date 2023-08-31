#!/bin/bash

# Navigate to the cmake directory
cd projects/cmake

# Run CMake
cmake -G "Unix Makefiles" .

# Check if CMake ran successfully
if [ $? -ne 0 ]; then
    echo "CMake configuration failed."
    exit 1
fi

# Run Make
make

# Check if Make ran successfully
if [ $? -ne 0 ]; then
    echo "Make failed."
    exit 1
fi

# Navigate to the bin directory
cd ../../bin

# Run the sktest executable
./sktest

# Check if sktest ran successfully
if [ $? -ne 0 ]; then
    echo "sktest execution failed."
    exit 1
fi

# Display completion message
echo "Done!"
