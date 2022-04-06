module ContentManager.Core.Constructors

open System
open ContentManager.Core
open Types

[<RequireQualifiedAccess>]
module ItemElementConstructor =
    let Create article typeId ``type`` name =
        { Article = article
          TypeId = typeId
          Type = ``type``
          Name = name }
    let Default() =
        { Article = String.Empty
          TypeId = 0
          Type = String.Empty
          Name = String.Empty }


[<RequireQualifiedAccess>]
module ItemParameterConstructor =
    let Create parameterId valueType displayName revitName =
        { ParameterId = parameterId
          ValueType = valueType
          DisplayName = displayName
          RevitName = revitName }
    let Default() =
        { ParameterId = String.Empty
          ValueType = String.Empty
          DisplayName = String.Empty
          RevitName = String.Empty }


[<RequireQualifiedAccess>]
module ItemTypeConstructor =
    let Create typeId name parameters =
        { TypeId = typeId
          Name = name
          Parameters = parameters }
    let Default() =
        { TypeId = 0
          Name = String.Empty
          Parameters = [] }


[<RequireQualifiedAccess>]
module TypeParameterConstructor =
    let Create id typeId parameterId =
        { Id = id
          TypeId = typeId
          ParameterId = parameterId }
    let Default() =
        { Id = 0
          TypeId = 0
          ParameterId = String.Empty }


[<RequireQualifiedAccess>]
module ParameterValueConstructor =
    let Create id article parameterId value =
        { Id = id
          Article = article
          ParameterId = parameterId
          Value = value
          SomeProp = failwith "todo" }
    let Default() =
        { Id = 0
          Article = String.Empty
          ParameterId = String.Empty
          Value = String.Empty
          SomeProp = failwith "todo" }


[<RequireQualifiedAccess>]
module ContextConstructor =
    let Create element parameters types typeParameters parameterValues =
        { Elements = element
          Parameters = parameters
          Types = types
          TypeParameters = typeParameters
          ParameterValues = parameterValues }
    let Default() =
        { Elements = []
          Parameters = []
          Types = []
          TypeParameters = []
          ParameterValues = [] }