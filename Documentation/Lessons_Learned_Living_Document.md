# These are some lessons learned during the course of the project's development:

* As of .Net Core 2.2, the System.Console class does not offer a robust means of interacting with terminals on MacOS or Linux.  For this reason, the decision was made to forgo a textmode library runner for the time being and focus on building graphical tools.

* Because of the timing problems inherent in calling methods defined in child classes from parent classes in C#, there is no clean or simple way to ensure in an abstract class that all children classes implement a particular named, field-like, unchanging, readonly value that is defined in the children classes AND can be relied on in the parent’s constructor.  For this reason, the parquet classes that inherit from ParquetParent pass constant values needed for runtime ID validation to their base class as part of their Constructor.

* Because there may be at least as many items as parquets the ItemID range has been defined using reflection to determine the amount of space in the parquet ranges.

* Visual Studio 2019 seems to occasionally not run unit tests as expected, instead reporting old results stored in the cache.  Clearing the cache folder does the trick.  This post explains how clearing the test cache can be made a part of the project Clean build step:  https://blogs.msdn.microsoft.com/ploeh/2006/07/13/cleaning-away-the-testresults-folder/

* I considered merging MapSpace with BeingLocation because they are nearly the same thing, but in this case the domains where they are used are so distinct it seemed wiser to reflect in their comments where and how they are used.  This decision can easily be changed down the road if the domains do end up overlapping.

* .Net Core doesn't support loading unmanaged libraries as well as Mono or .Net Framework did.  Specifically, as of Jan 2020 .Net Core does not automatically map libraries with one name on one platform to another name on another platform.  Worse yet, the library import code does not allow the client developer to provide the mapping either.  There are various workarounds.  But it may be easiest simply to retarget from Core to Framework where possible when it comes time to release.  This situation may be a nonissue by the time Parquet is ready.

* Since C# does not support static methods in interfaces and also cannot invoke static methods using a generic type argument, one way to support access to class-scoped members within a generic method is to provide each implementing class of a given interface with a static method, and then compose a unit test to ensure via reflection that all classes that implement the interface do indeed implement a method with that signature.  A single instance of the class can be cached in a dictionary, matching `typeof(ImplementingClass)` with `ImplementingClass.StaticMethod`, thus creating a simple runtime static fill C#'s gap.

* It is sometimes practical to provide a public parameterless constructor to a class that otherwise should not have one, so that the class may be dealt with more easily from within generic methods.  While messy from an API perspective, the limitations of C#'s generics prevent cleaner approaches.