#rush weigelt reextend try1

for i in * ; do
	filename="${i}"  
	extension="${filename##*.}" 
	filename="${filename%.*}" 
	echo "$extension"
	 
	if [[ -z "$1" || -z "$2" || -n "$3" ]] ; then
	echo "We are looking for EXACTLY two arguments please!"
	else
		for i in *$1 ; do
			mv "$i" "${i/$1/$2}"
		done
	fi 	
done
