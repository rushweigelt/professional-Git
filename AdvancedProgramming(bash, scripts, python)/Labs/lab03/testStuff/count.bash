# First attempt at a bash script. Scary.
#Rush Weigelt rw643 rename files script 
# version 4.3.48(1)-release (x86_64-pc-linux-gnu) 
# 4/20/18
read -p "Do you want to see the script as it executes? (y/[n]) => " debugOn
if [ "$debugOn" == "y" -o "$debugOn" == "Y" ] ; then
	set -x
fi

for i in * ; do
	if [ -f "${i}" ] ; then
	echo -n "${i}" ;
	echo -n " " ;
	echo -n $( cat "${i}" | wc -l ) ;
	echo -n " " ;
	echo -n $( cat "${i}" | wc -w ) ;
	echo " " ;
	fi
done
