#!/bin/bash
#rush weigelt

file="$1"
python <<END
import sys
#open our file
ourFile = open("$file", "r")
#create empty lists we will save to later
idsNamesDict={}
#break up 'ids' into lines
for line in ourFile:
	words=line.split()
	#for each line, the first word is an ID, everything else is the name. We 
	#convert the string ID to an int here for sorting purposes later.
	idsNamesDict[int(words[0])] = ' '.join(words[1:])
#loop that prints our dictionary key and entry, sorted by the keys numeric values 
for key in sorted(idsNamesDict):
	print '{0} {1}'.format(key, idsNamesDict[key]) 
END
