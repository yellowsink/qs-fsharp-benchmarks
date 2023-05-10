#!/bin/sh

GOOFY_FILENAME=fewdoioaatdaiephoayutpdrt

# buffering issues :(
cp dist/App.rs /tmp/$GOOFY_FILENAME
cat /tmp/$GOOFY_FILENAME | sed "s/..\/benchmarks/benchmarks/g" > dist/App.rs
rm /tmp/$GOOFY_FILENAME