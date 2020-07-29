<a name='assembly'></a>
# Roller

## Contents

- [Command](#T-ParquetRoller-Roller-Command 'ParquetRoller.Roller.Command')
- [ExitCode](#T-ParquetRoller-ExitCode 'ParquetRoller.ExitCode')
  - [AccessDenied](#F-ParquetRoller-ExitCode-AccessDenied 'ParquetRoller.ExitCode.AccessDenied')
  - [BadArguments](#F-ParquetRoller-ExitCode-BadArguments 'ParquetRoller.ExitCode.BadArguments')
  - [FileNotFound](#F-ParquetRoller-ExitCode-FileNotFound 'ParquetRoller.ExitCode.FileNotFound')
  - [InvalidData](#F-ParquetRoller-ExitCode-InvalidData 'ParquetRoller.ExitCode.InvalidData')
  - [NotSupported](#F-ParquetRoller-ExitCode-NotSupported 'ParquetRoller.ExitCode.NotSupported')
  - [Success](#F-ParquetRoller-ExitCode-Success 'ParquetRoller.ExitCode.Success')
- [Resources](#T-ParquetRoller-Properties-Resources 'ParquetRoller.Properties.Resources')
  - [Culture](#P-ParquetRoller-Properties-Resources-Culture 'ParquetRoller.Properties.Resources.Culture')
  - [ErrorNoProperty](#P-ParquetRoller-Properties-Resources-ErrorNoProperty 'ParquetRoller.Properties.Resources.ErrorNoProperty')
  - [ErrorUnknownCategory](#P-ParquetRoller-Properties-Resources-ErrorUnknownCategory 'ParquetRoller.Properties.Resources.ErrorUnknownCategory')
  - [ErrorUnknownProperty](#P-ParquetRoller-Properties-Resources-ErrorUnknownProperty 'ParquetRoller.Properties.Resources.ErrorUnknownProperty')
  - [InfoCollision](#P-ParquetRoller-Properties-Resources-InfoCollision 'ParquetRoller.Properties.Resources.InfoCollision')
  - [InfoCollisionsHeader](#P-ParquetRoller-Properties-Resources-InfoCollisionsHeader 'ParquetRoller.Properties.Resources.InfoCollisionsHeader')
  - [InfoNoContent](#P-ParquetRoller-Properties-Resources-InfoNoContent 'ParquetRoller.Properties.Resources.InfoNoContent')
  - [MessageChecking](#P-ParquetRoller-Properties-Resources-MessageChecking 'ParquetRoller.Properties.Resources.MessageChecking')
  - [MessageDefault](#P-ParquetRoller-Properties-Resources-MessageDefault 'ParquetRoller.Properties.Resources.MessageDefault')
  - [MessageHelp](#P-ParquetRoller-Properties-Resources-MessageHelp 'ParquetRoller.Properties.Resources.MessageHelp')
  - [MessageVersion](#P-ParquetRoller-Properties-Resources-MessageVersion 'ParquetRoller.Properties.Resources.MessageVersion')
  - [ResourceManager](#P-ParquetRoller-Properties-Resources-ResourceManager 'ParquetRoller.Properties.Resources.ResourceManager')
- [Roller](#T-ParquetRoller-Roller 'ParquetRoller.Roller')
  - [ListPropertyForCategory](#P-ParquetRoller-Roller-ListPropertyForCategory 'ParquetRoller.Roller.ListPropertyForCategory')
  - [CheckAdjacency(inWorkload)](#M-ParquetRoller-Roller-CheckAdjacency-ParquetClassLibrary-ModelCollection- 'ParquetRoller.Roller.CheckAdjacency(ParquetClassLibrary.ModelCollection)')
  - [CreateTemplates(inWorkload)](#M-ParquetRoller-Roller-CreateTemplates-ParquetClassLibrary-ModelCollection- 'ParquetRoller.Roller.CreateTemplates(ParquetClassLibrary.ModelCollection)')
  - [DisplayBadArguments(inWorkload)](#M-ParquetRoller-Roller-DisplayBadArguments-ParquetClassLibrary-ModelCollection- 'ParquetRoller.Roller.DisplayBadArguments(ParquetClassLibrary.ModelCollection)')
  - [DisplayDefault(inWorkload)](#M-ParquetRoller-Roller-DisplayDefault-ParquetClassLibrary-ModelCollection- 'ParquetRoller.Roller.DisplayDefault(ParquetClassLibrary.ModelCollection)')
  - [DisplayHelp(inWorkload)](#M-ParquetRoller-Roller-DisplayHelp-ParquetClassLibrary-ModelCollection- 'ParquetRoller.Roller.DisplayHelp(ParquetClassLibrary.ModelCollection)')
  - [DisplayVersion(inWorkload)](#M-ParquetRoller-Roller-DisplayVersion-ParquetClassLibrary-ModelCollection- 'ParquetRoller.Roller.DisplayVersion(ParquetClassLibrary.ModelCollection)')
  - [ListCollisions(inWorkload)](#M-ParquetRoller-Roller-ListCollisions-ParquetClassLibrary-ModelCollection- 'ParquetRoller.Roller.ListCollisions(ParquetClassLibrary.ModelCollection)')
  - [ListMaxIDs(inWorkload)](#M-ParquetRoller-Roller-ListMaxIDs-ParquetClassLibrary-ModelCollection- 'ParquetRoller.Roller.ListMaxIDs(ParquetClassLibrary.ModelCollection)')
  - [ListNames(inWorkload)](#M-ParquetRoller-Roller-ListNames-ParquetClassLibrary-ModelCollection- 'ParquetRoller.Roller.ListNames(ParquetClassLibrary.ModelCollection)')
  - [ListPronouns(inWorkload)](#M-ParquetRoller-Roller-ListPronouns-ParquetClassLibrary-ModelCollection- 'ParquetRoller.Roller.ListPronouns(ParquetClassLibrary.ModelCollection)')
  - [ListRanges(inWorkload)](#M-ParquetRoller-Roller-ListRanges-ParquetClassLibrary-ModelCollection- 'ParquetRoller.Roller.ListRanges(ParquetClassLibrary.ModelCollection)')
  - [ListTags(inWorkload)](#M-ParquetRoller-Roller-ListTags-ParquetClassLibrary-ModelCollection- 'ParquetRoller.Roller.ListTags(ParquetClassLibrary.ModelCollection)')
  - [Main(args)](#M-ParquetRoller-Roller-Main-System-String[]- 'ParquetRoller.Roller.Main(System.String[])')
  - [ParseCategory(inCategory)](#M-ParquetRoller-Roller-ParseCategory-System-String- 'ParquetRoller.Roller.ParseCategory(System.String)')
  - [ParseCommand(inCommandText)](#M-ParquetRoller-Roller-ParseCommand-System-String- 'ParquetRoller.Roller.ParseCommand(System.String)')
  - [ParseProperty(inProperty)](#M-ParquetRoller-Roller-ParseProperty-System-String- 'ParquetRoller.Roller.ParseProperty(System.String)')
  - [RollCSVs(inWorkload)](#M-ParquetRoller-Roller-RollCSVs-ParquetClassLibrary-ModelCollection- 'ParquetRoller.Roller.RollCSVs(ParquetClassLibrary.ModelCollection)')

<a name='T-ParquetRoller-Roller-Command'></a>
## Command `type`

##### Namespace

ParquetRoller.Roller

##### Summary

Represents an action that the user may ask [Roller](#T-ParquetRoller-Roller 'ParquetRoller.Roller') to perform.

##### Returns

A value indicating success or the manner of failure.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inWorkload | [T:ParquetRoller.Roller.Command](#T-T-ParquetRoller-Roller-Command 'T:ParquetRoller.Roller.Command') | The [ModelCollection](#T-ParquetClassLibrary-ModelCollection 'ParquetClassLibrary.ModelCollection') to act on, if any. |

<a name='T-ParquetRoller-ExitCode'></a>
## ExitCode `type`

##### Namespace

ParquetRoller

##### Summary

A value indicating success or the nature of the failure.

##### Remarks

Returned when the application terminates to indicate results of the process.

<a name='F-ParquetRoller-ExitCode-AccessDenied'></a>
### AccessDenied `constants`

##### Summary

Access or permission was denied.

<a name='F-ParquetRoller-ExitCode-BadArguments'></a>
### BadArguments `constants`

##### Summary

One or more arguments were incorrect.

<a name='F-ParquetRoller-ExitCode-FileNotFound'></a>
### FileNotFound `constants`

##### Summary

An invalid function was specified.

<a name='F-ParquetRoller-ExitCode-InvalidData'></a>
### InvalidData `constants`

##### Summary

Invalid data was given.

<a name='F-ParquetRoller-ExitCode-NotSupported'></a>
### NotSupported `constants`

##### Summary

An unsupported request was made.

<a name='F-ParquetRoller-ExitCode-Success'></a>
### Success `constants`

##### Summary

The operation completed successfully.

<a name='T-ParquetRoller-Properties-Resources'></a>
## Resources `type`

##### Namespace

ParquetRoller.Properties

##### Summary

A strongly-typed resource class, for looking up localized strings, etc.

<a name='P-ParquetRoller-Properties-Resources-Culture'></a>
### Culture `property`

##### Summary

Overrides the current thread's CurrentUICulture property for all
  resource lookups using this strongly typed resource class.

<a name='P-ParquetRoller-Properties-Resources-ErrorNoProperty'></a>
### ErrorNoProperty `property`

##### Summary

Looks up a localized string similar to Specify property.
.

<a name='P-ParquetRoller-Properties-Resources-ErrorUnknownCategory'></a>
### ErrorUnknownCategory `property`

##### Summary

Looks up a localized string similar to Unrecognized category{0}.
.

<a name='P-ParquetRoller-Properties-Resources-ErrorUnknownProperty'></a>
### ErrorUnknownProperty `property`

##### Summary

Looks up a localized string similar to Unrecognized property {0}.
.

<a name='P-ParquetRoller-Properties-Resources-InfoCollision'></a>
### InfoCollision `property`

##### Summary

Looks up a localized string similar to {0}: {1} collides with {2}.
.

<a name='P-ParquetRoller-Properties-Resources-InfoCollisionsHeader'></a>
### InfoCollisionsHeader `property`

##### Summary

Looks up a localized string similar to Collisions in {0}:
.

<a name='P-ParquetRoller-Properties-Resources-InfoNoContent'></a>
### InfoNoContent `property`

##### Summary

Looks up a localized string similar to No defined content.
.

<a name='P-ParquetRoller-Properties-Resources-MessageChecking'></a>
### MessageChecking `property`

##### Summary

Looks up a localized string similar to Checking {0}..

<a name='P-ParquetRoller-Properties-Resources-MessageDefault'></a>
### MessageDefault `property`

##### Summary

Looks up a localized string similar to Usage: roller (command)

Commands:
    -h|help Display detailed help.
    -v|version          Display version information.
    -t|templates        Write CSV templates to current directory.
    -r|roll Prepare CSVs in current directory for use.
    -c|checkCheck that map adjacency is consistent.
    -p|list pronouns    List  [rest of string was truncated]";.

<a name='P-ParquetRoller-Properties-Resources-MessageHelp'></a>
### MessageHelp `property`

##### Summary

Looks up a localized string similar to     Roller is a tool for working with Parquet configuration files.
    Parquet uses comma-separated value (CSV) files for configuration.
    Roller provides a quick way to examine the content of existing CSV files, to
    generate blank CSV files, and to prepare existing CSV files for use in-game.

Usage: roller (command)

Commands:
    -h|help Display detailed help.
    -v|version          Di [rest of string was truncated]";.

<a name='P-ParquetRoller-Properties-Resources-MessageVersion'></a>
### MessageVersion `property`

##### Summary

Looks up a localized string similar to Version:
    Roller      {0}
    Parquet     {1}
.

<a name='P-ParquetRoller-Properties-Resources-ResourceManager'></a>
### ResourceManager `property`

##### Summary

Returns the cached ResourceManager instance used by this class.

<a name='T-ParquetRoller-Roller'></a>
## Roller `type`

##### Namespace

ParquetRoller

##### Summary

A command line tool that reads in game definitions from CSV files, verifies, modifies, and writes them out.

<a name='P-ParquetRoller-Roller-ListPropertyForCategory'></a>
### ListPropertyForCategory `property`

##### Summary

A flag indicating that a subcommand must be executed.

<a name='M-ParquetRoller-Roller-CheckAdjacency-ParquetClassLibrary-ModelCollection-'></a>
### CheckAdjacency(inWorkload) `method`

##### Summary

Check for inconsistent adjacency information in all defined [MapRegion](#T-ParquetClassLibrary-Maps-MapRegion 'ParquetClassLibrary.Maps.MapRegion')s and [MapRegionSketch](#T-ParquetClassLibrary-Maps-MapRegionSketch 'ParquetClassLibrary.Maps.MapRegionSketch')es.

##### Returns

A value indicating success or the nature of the failure.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inWorkload | [ParquetClassLibrary.ModelCollection](#T-ParquetClassLibrary-ModelCollection 'ParquetClassLibrary.ModelCollection') | Ignored. |

<a name='M-ParquetRoller-Roller-CreateTemplates-ParquetClassLibrary-ModelCollection-'></a>
### CreateTemplates(inWorkload) `method`

##### Summary

Write CSV templates to current directory.

##### Returns

A value indicating success or the nature of the failure.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inWorkload | [ParquetClassLibrary.ModelCollection](#T-ParquetClassLibrary-ModelCollection 'ParquetClassLibrary.ModelCollection') | Ignored. |

<a name='M-ParquetRoller-Roller-DisplayBadArguments-ParquetClassLibrary-ModelCollection-'></a>
### DisplayBadArguments(inWorkload) `method`

##### Summary

Displays the help message to the user, also indicating that the arguments given were not understood.

##### Returns

[BadArguments](#F-ParquetRoller-ExitCode-BadArguments 'ParquetRoller.ExitCode.BadArguments')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inWorkload | [ParquetClassLibrary.ModelCollection](#T-ParquetClassLibrary-ModelCollection 'ParquetClassLibrary.ModelCollection') | Ignored. |

<a name='M-ParquetRoller-Roller-DisplayDefault-ParquetClassLibrary-ModelCollection-'></a>
### DisplayDefault(inWorkload) `method`

##### Summary

Displays the default message to the user.

##### Returns

[Success](#F-ParquetRoller-ExitCode-Success 'ParquetRoller.ExitCode.Success')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inWorkload | [ParquetClassLibrary.ModelCollection](#T-ParquetClassLibrary-ModelCollection 'ParquetClassLibrary.ModelCollection') | Ignored. |

<a name='M-ParquetRoller-Roller-DisplayHelp-ParquetClassLibrary-ModelCollection-'></a>
### DisplayHelp(inWorkload) `method`

##### Summary

Displays a detailed help message to the user.

##### Returns

[Success](#F-ParquetRoller-ExitCode-Success 'ParquetRoller.ExitCode.Success')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inWorkload | [ParquetClassLibrary.ModelCollection](#T-ParquetClassLibrary-ModelCollection 'ParquetClassLibrary.ModelCollection') | Ignored. |

<a name='M-ParquetRoller-Roller-DisplayVersion-ParquetClassLibrary-ModelCollection-'></a>
### DisplayVersion(inWorkload) `method`

##### Summary

Displays version information to the user.

##### Returns

[Success](#F-ParquetRoller-ExitCode-Success 'ParquetRoller.ExitCode.Success')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inWorkload | [ParquetClassLibrary.ModelCollection](#T-ParquetClassLibrary-ModelCollection 'ParquetClassLibrary.ModelCollection') | Ignored. |

<a name='M-ParquetRoller-Roller-ListCollisions-ParquetClassLibrary-ModelCollection-'></a>
### ListCollisions(inWorkload) `method`

##### Summary

If more than one unique [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model') uses the same [Name](#P-ParquetClassLibrary-Model-Name 'ParquetClassLibrary.Model.Name'), lists that as a name collision.

##### Returns

[BadArguments](#F-ParquetRoller-ExitCode-BadArguments 'ParquetRoller.ExitCode.BadArguments')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inWorkload | [ParquetClassLibrary.ModelCollection](#T-ParquetClassLibrary-ModelCollection 'ParquetClassLibrary.ModelCollection') | The [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model')s to inspect. |

<a name='M-ParquetRoller-Roller-ListMaxIDs-ParquetClassLibrary-ModelCollection-'></a>
### ListMaxIDs(inWorkload) `method`

##### Summary

Lists the largest [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID') actually in use in each of the given categories of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model')s.

##### Returns

[Success](#F-ParquetRoller-ExitCode-Success 'ParquetRoller.ExitCode.Success')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inWorkload | [ParquetClassLibrary.ModelCollection](#T-ParquetClassLibrary-ModelCollection 'ParquetClassLibrary.ModelCollection') | The [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model')s to inspect. |

<a name='M-ParquetRoller-Roller-ListNames-ParquetClassLibrary-ModelCollection-'></a>
### ListNames(inWorkload) `method`

##### Summary

Lists every unique [Name](#P-ParquetClassLibrary-Model-Name 'ParquetClassLibrary.Model.Name') in use in each of the given [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model')s.

##### Returns

[Success](#F-ParquetRoller-ExitCode-Success 'ParquetRoller.ExitCode.Success')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inWorkload | [ParquetClassLibrary.ModelCollection](#T-ParquetClassLibrary-ModelCollection 'ParquetClassLibrary.ModelCollection') | The [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model')s to inspect. |

<a name='M-ParquetRoller-Roller-ListPronouns-ParquetClassLibrary-ModelCollection-'></a>
### ListPronouns(inWorkload) `method`

##### Summary

List all defined pronoun groups.

##### Returns

A value indicating success or the nature of the failure.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inWorkload | [ParquetClassLibrary.ModelCollection](#T-ParquetClassLibrary-ModelCollection 'ParquetClassLibrary.ModelCollection') | Ignored. |

<a name='M-ParquetRoller-Roller-ListRanges-ParquetClassLibrary-ModelCollection-'></a>
### ListRanges(inWorkload) `method`

##### Summary

Lists the defined ranges for the given [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model')s' [ModelID](#T-ParquetClassLibrary-ModelID 'ParquetClassLibrary.ModelID')s.

##### Returns

[Success](#F-ParquetRoller-ExitCode-Success 'ParquetRoller.ExitCode.Success')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inWorkload | [ParquetClassLibrary.ModelCollection](#T-ParquetClassLibrary-ModelCollection 'ParquetClassLibrary.ModelCollection') | The [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model')s to inspect. |

<a name='M-ParquetRoller-Roller-ListTags-ParquetClassLibrary-ModelCollection-'></a>
### ListTags(inWorkload) `method`

##### Summary

Lists every unique [ModelTag](#T-ParquetClassLibrary-ModelTag 'ParquetClassLibrary.ModelTag') in use in each of the given [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model')s.

##### Returns

[BadArguments](#F-ParquetRoller-ExitCode-BadArguments 'ParquetRoller.ExitCode.BadArguments')

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inWorkload | [ParquetClassLibrary.ModelCollection](#T-ParquetClassLibrary-ModelCollection 'ParquetClassLibrary.ModelCollection') | The [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model')s to inspect. |

<a name='M-ParquetRoller-Roller-Main-System-String[]-'></a>
### Main(args) `method`

##### Summary

A command line tool for working with Parquet configuration files.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| args | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | Command line arguments passed in to the tool. |

<a name='M-ParquetRoller-Roller-ParseCategory-System-String-'></a>
### ParseCategory(inCategory) `method`

##### Summary

Takes a single argument corresponding to the "category" selection and determines which workload it corresponds to.

##### Returns

A collection of [Model](#T-ParquetClassLibrary-Model 'ParquetClassLibrary.Model')s to take action on.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inCategory | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The third command line argument. |

<a name='M-ParquetRoller-Roller-ParseCommand-System-String-'></a>
### ParseCommand(inCommandText) `method`

##### Summary

Takes a single argument corresponding to the "command" selection and determines which command it corresponds to.

##### Returns

An action for [Roller](#T-ParquetRoller-Roller 'ParquetRoller.Roller') to take.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inCommandText | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The first command line argument. |

<a name='M-ParquetRoller-Roller-ParseProperty-System-String-'></a>
### ParseProperty(inProperty) `method`

##### Summary

Takes a single argument corresponding to the "property" selection and determines which subcommand it corresponds to.

##### Returns

An action for [Roller](#T-ParquetRoller-Roller 'ParquetRoller.Roller') to take.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inProperty | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The second command line argument. |

<a name='M-ParquetRoller-Roller-RollCSVs-ParquetClassLibrary-ModelCollection-'></a>
### RollCSVs(inWorkload) `method`

##### Summary

Prepare CSVs in current directory for use.

##### Returns

A value indicating success or the nature of the failure.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| inWorkload | [ParquetClassLibrary.ModelCollection](#T-ParquetClassLibrary-ModelCollection 'ParquetClassLibrary.ModelCollection') | Ignored. |
