#Rush Weigelt rw643 rename files script
# version 4.3.48(1)-release (x86_64-pc-linux-gnu)
# 4/20/18

if [[ -z "$1" || -z "$2" || -n "$3" ]] ; then
	echo "We are looking for EXACTLY two arguments please!"
else
	for i in *$1 ; do
		mv "$i" "${i/$1/$2}"
	done         
fi
