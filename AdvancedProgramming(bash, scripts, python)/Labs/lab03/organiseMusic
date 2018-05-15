#Rush Weigelt rw643 reorganize music script v2 
# version 4.3.48(1)-release (x86_64-pc-linux-gnu) 
# 4/22/18
#!/bin/bash

for i in *.mp3 ; do
	band="${i%\ -\ *}"  ;
	song="${i##*\ -\ }" ;
	#these two lines were here for personal testing
	#echo "$band"
	#echo "$song"
	
	if [ ! -d "$band" ] ; then
		mkdir "$band" ;
		mv "$i" "$song" ;
		mv "$band" "$song" ;
		mv "$song" "$band" ;
	else
		mv "$i" "$song" ;
		mv "$song" "$band" ;
	fi
done
