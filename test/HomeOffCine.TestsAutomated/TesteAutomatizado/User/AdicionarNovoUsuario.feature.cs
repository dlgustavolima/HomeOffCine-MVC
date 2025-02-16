﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace HomeOffCine.TestsAutomated.TesteAutomatizado.User
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class User_CadastrarNovoUsuarioFeature : object, Xunit.IClassFixture<User_CadastrarNovoUsuarioFeature.FixtureData>, Xunit.IAsyncLifetime
    {
        
        private static global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "AdicionarNovoUsuario.feature"
#line hidden
        
        public User_CadastrarNovoUsuarioFeature(User_CadastrarNovoUsuarioFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
        }
        
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(null, global::Reqnroll.xUnit.ReqnrollPlugin.XUnitParallelWorkerTracker.Instance.GetWorkerId());
            global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "TesteAutomatizado/User", "User - Cadastrar novo usuario", "\tComo um visitante\r\n\tEu desejo criar um novo usuario\r\n\tPara que eu possa acessar " +
                    "as demais funcionalidades", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
            await testRunner.OnFeatureStartAsync(featureInfo);
        }
        
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
            string testWorkerId = testRunner.TestWorkerId;
            await testRunner.OnFeatureEndAsync();
            testRunner = null;
            global::Reqnroll.xUnit.ReqnrollPlugin.XUnitParallelWorkerTracker.Instance.ReleaseWorker(testWorkerId);
        }
        
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
        }
        
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
        {
            await this.TestInitializeAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
        {
            await this.TestTearDownAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Entrar na tela de cadastro de usuario")]
        [Xunit.TraitAttribute("FeatureTitle", "User - Cadastrar novo usuario")]
        [Xunit.TraitAttribute("Description", "Entrar na tela de cadastro de usuario")]
        public async System.Threading.Tasks.Task EntrarNaTelaDeCadastroDeUsuario()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Entrar na tela de cadastro de usuario", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 7
await testRunner.GivenAsync("Que o usuario acessou o site", ((string)(null)), ((global::Reqnroll.Table)(null)), "Dado ");
#line hidden
#line 8
await testRunner.WhenAsync("Ele clicar em cadastrar", ((string)(null)), ((global::Reqnroll.Table)(null)), "Quando ");
#line hidden
#line 9
await testRunner.ThenAsync("O usuario será redirecionado para a tela com o formulario de cadastro", ((string)(null)), ((global::Reqnroll.Table)(null)), "Então ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Cadastrar novo usuario com sucesso")]
        [Xunit.TraitAttribute("FeatureTitle", "User - Cadastrar novo usuario")]
        [Xunit.TraitAttribute("Description", "Cadastrar novo usuario com sucesso")]
        public async System.Threading.Tasks.Task CadastrarNovoUsuarioComSucesso()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Cadastrar novo usuario com sucesso", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 11
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 12
await testRunner.GivenAsync("Que o usuario acessou o site", ((string)(null)), ((global::Reqnroll.Table)(null)), "Dado ");
#line hidden
#line 13
await testRunner.WhenAsync("Ele clicar em cadastrar", ((string)(null)), ((global::Reqnroll.Table)(null)), "Quando ");
#line hidden
                global::Reqnroll.Table table1 = new global::Reqnroll.Table(new string[] {
                            "Dados"});
                table1.AddRow(new string[] {
                            "E-mail"});
                table1.AddRow(new string[] {
                            "Senha"});
                table1.AddRow(new string[] {
                            "Confirmação da Senha"});
#line 14
await testRunner.AndAsync("E Preencher os dados do formulario", ((string)(null)), table1, "E ");
#line hidden
#line 19
await testRunner.AndAsync("Clicar no botão cadastrar", ((string)(null)), ((global::Reqnroll.Table)(null)), "E ");
#line hidden
#line 20
await testRunner.ThenAsync("O usuario será redirecionado para a Home", ((string)(null)), ((global::Reqnroll.Table)(null)), "Então ");
#line hidden
#line 21
await testRunner.AndAsync("Uma saudação com seu e-mail será exibida no menu superior", ((string)(null)), ((global::Reqnroll.Table)(null)), "E ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : object, Xunit.IAsyncLifetime
        {
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
            {
                await User_CadastrarNovoUsuarioFeature.FeatureSetupAsync();
            }
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
            {
                await User_CadastrarNovoUsuarioFeature.FeatureTearDownAsync();
            }
        }
    }
}
#pragma warning restore
#endregion
