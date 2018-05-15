#!/bin/bash
#Rush Weigelt
#4/24/18

gcc -osign sign.c
./sign < /usr/share/dict/words | sort | awk -f squash.awk > out
awk '{print NF " " $0}' < out | sort -n | tail

