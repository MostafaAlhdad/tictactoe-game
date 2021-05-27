
debug:
	mcs -t:library ./ref/components/*.cs -out:Bin/Debug/components.dll -debug
	mcs -r:Bin/Debug/components.dll ./src/*.cs -out:Bin/Debug/test.exe -debug
	mono ./Bin/Debug/test.exe -v

release:
	mcs -t:library ./ref/components/*.cs -out:Bin/Release/components.dll
	mcs -r:Bin/Release/components.dll ./src/*.cs -out:Bin/Release/test.exe

clean:
	rm ./Bin/Debug/*
