module ContentManager.Core.Literals

open ContentManager.Core
open ContentManager.Utils
open Reflection
open Types

type SF() =
    // Item Element
    static member val Article         = GetPropertyName <@ fun (i: ItemElement)    -> i.Article @>
    static member val TypeId          = GetPropertyName <@ fun (i: ItemElement)    -> i.TypeId @>
    static member val Type            = GetPropertyName <@ fun (i: ItemElement)    -> i.Type @>
    static member val Name            = GetPropertyName <@ fun (i: ItemElement)    -> i.Name @>

    // Item Parameter
    static member val ParameterId     = GetPropertyName <@ fun (i: ItemParameter)  -> i.ParameterId @>
    static member val ValueType       = GetPropertyName <@ fun (i: ItemParameter)  -> i.ValueType @>
    static member val DisplayName     = GetPropertyName <@ fun (i: ItemParameter)  -> i.DisplayName @>
    static member val RevitName       = GetPropertyName <@ fun (i: ItemParameter)  -> i.RevitName @>

    static member val Id              = GetPropertyName <@ fun (i: TypeParameter)  -> i.Id @>

    static member val Value           = GetPropertyName <@ fun (i: ParameterValue) -> i.Value @>

    // Context
    static member val Elements        = GetPropertyName <@ fun (i: Context)        -> i.Elements @>
    static member val Parameters      = GetPropertyName <@ fun (i: Context)        -> i.Parameters @>
    static member val Types           = GetPropertyName <@ fun (i: Context)        -> i.Types @>
    static member val TypeParameters  = GetPropertyName <@ fun (i: Context)        -> i.TypeParameters @>
    static member val ParameterValues = GetPropertyName <@ fun (i: Context)        -> i.ParameterValues @>

    static member val AllSheets =
        [ (SF.Elements,         [ SF.Article; SF.TypeId; SF.Name ])
          (SF.Types,            [ SF.TypeId; SF.Name ])
          (SF.Parameters,       [ SF.ParameterId; SF.ValueType; SF.DisplayName; SF.RevitName ])
          (SF.TypeParameters,   [ SF.Id; SF.TypeId; SF.ParameterId ])
          (SF.ParameterValues,  [ SF.Id; SF.Article; SF.ParameterId; SF.Value ]) ]