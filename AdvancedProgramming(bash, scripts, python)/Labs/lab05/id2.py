#!/usr/bin/python3
#rush weigelt

import sys
import fileinput

#file name given
try:
	#open file
	ourFile = open(sys.argv[1], "r")
	#create an emtpy dict to save to
	idsNamesDict = {} 
	#break file into lines 
	for line in ourFile:
		#split by space         
		words = line.split()
		#convert first word in line to int for sorting, join rest of list as a single str         
		idsNamesDict[int(words[0])] = ' '.join(words[1:])  
	#print in columns
	for key in sorted(idsNamesDict):         
		print('{0} {1}'.format(key, idsNamesDict[key]))
#no file name given
except:
	#let user know how to end input prompt
	print('enter "quit" to stop entering lines')
	idsNamesDict = {}
	#while loop that strips input lines of newspace, then strips and sorts them like above unless 
	#user types 'quit', which ends the loop and prints out results.
	go = True
	while go: 
		ourFile = sys.stdin.readline().strip('\n')
		#if user types 'quit', end the loop
		if ourFile == "quit":
			go = False
		#else, repeat strip and store from above
		else:		
			words = ourFile.split()
			idsNamesDict[int(words[0])] = ' '.join(words[1:])
	#print results
	for key in sorted(idsNamesDict):
		print('{0} {1}'.format(key, idsNamesDict[key]))
