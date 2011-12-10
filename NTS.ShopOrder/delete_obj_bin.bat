
FOR /R %%f IN (.) DO (
	if "%%~nf"=="obj" (
		rmdir /S /Q "%%f"
	)
	if "%%~nf"=="bin"	(	
		rmdir /S /Q "%%f"
	)

)
