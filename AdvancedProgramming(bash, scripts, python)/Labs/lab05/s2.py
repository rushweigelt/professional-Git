#!/bin/bash
#rush weigelt

file="$1"
python <<END
import sys
#open our file
ourFile = open("$file", "r")
#create empty lists we will save to later
names=[]
grades=[]
avgs=[]
#break up 'students' into lines
for line in ourFile:
	words=line.split(',')
	#for each line, the first word is name, append name to names list
	names.append(words[0])
	#everything after name is a grade 
	grades.append(words[1:])
i=0
#for the lists in grades list, convert from string to int, iterate over our list of grade lists
for lists in grades:
	grades[i] = list(map(float, grades[i]))	
	avg=sum(grades[i])/len(grades[i])
	avgs.append(avg)
	i += 1
i=0
#final print statement name, avg seperated by a space
for out in names:
	print(str(names[i]) + ' ' + str(round(avgs[i],2)))
	i+=1
END
