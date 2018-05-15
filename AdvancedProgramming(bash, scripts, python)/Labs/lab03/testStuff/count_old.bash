#count alternate

for i in $PWD ; do
	if [-f "${i}" ] ; then
	echo -n "${i}"
	echo -n " "
	echo -n $( cat "${i}" | wc -l )
	fi
done
