#Rush Weigelt rw643 reorganize files script 
# version 4.3.48(1)-release (x86_64-pc-linux-gnu) 
# 4/20/18

for i in * ; do 
	#echo $i | cut -d'-' -f1 
	#name=$i 
	band=$(echo $i | cut -d '-' -f1)
	song=$(echo $i | cut -d '-' -f2)
 	#echo $name
	echo "$band"
	echo "$song"
	if [ ! -d "$band" ] ; then
		mkdir "$band"
		mv "$i" "$band"
		mv "$i" "$song"
	else
		mv "$i" "$band"
		mv "$i" "$song"
	fi 
done
