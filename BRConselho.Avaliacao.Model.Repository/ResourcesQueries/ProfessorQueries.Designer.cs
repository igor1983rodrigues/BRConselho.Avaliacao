﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BRConselho.Avaliacao.Model.Repository.ResourcesQueries {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ProfessorQueries {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ProfessorQueries() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BRConselho.Avaliacao.Model.Repository.ResourcesQueries.ProfessorQueries", typeof(ProfessorQueries).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select	ProfessorTemp.IdPessoa,
        ///		ProfessorTemp.IdPessoa,
        ///		ProfessorTemp.NomePessoa,
        ///		ProfessorTemp.MediaIdadeAlunos
        ///from	(select	Professor.oid_pessoa as IdPessoa,
        ///					--PessoaProfessor.oid_pessoa as IdPessoa,
        ///					PessoaProfessor.nome_pessoa as NomePessoa,
        ///					sum((current_date - Aluno.dt_nasc_aluno)/365) / count(Aluno.oid_pessoa) as MediaIdadeAlunos
        ///			from	tb_professor as Professor
        ///			inner	join tb_pessoa AS PessoaProfessor on Professor.oid_pessoa = PessoaProfessor.oid_pessoa
        ///			inner	join t [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string GetProfessorMediaIdadeAlunos {
            get {
                return ResourceManager.GetString("GetProfessorMediaIdadeAlunos", resourceCulture);
            }
        }
    }
}
