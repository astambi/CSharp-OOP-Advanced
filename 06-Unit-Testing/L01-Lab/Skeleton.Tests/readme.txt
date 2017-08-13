MSTest & Mock cannot be tested in Judge!

To test the solution in Judge:
	Use NUnit instead of MSTest
	Uninstall Moq & Castle.Core packages
	Comment all Mock code
	Comment all code in the Fakes folder using the newly created Interfaces in Skeleton	
	Comment HeroTests.cs for the above reason
	Zip and submit in Judge Skeleton.Tests only