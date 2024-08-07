using NetArchTest.Rules;

namespace LinkMe.Architecture.Tests
{
    public class ArchitectureTests
    {
        private const string DomainNamespace = "LinkMe.Domain";
        private const string ApplicationNamespace = "LinkMe.ApplicationServices";
        private const string InfrastructureNamespace = "LinkMe.Infrastructure";
        private const string WebNamespace = "LinkMe.Api";
        private const string PresentationNamespace = "LinkMe.Svelte";

        [Fact]
        public void Domain_Should_Not_HaveDependencyOnOtherProjects()
        {
            //act
            var result = Types.InCurrentDomain()
                .That()
                .ResideInNamespace(DomainNamespace)
                .ShouldNot()
                .HaveDependencyOnAny([
                    ApplicationNamespace,
                    InfrastructureNamespace,
                    PresentationNamespace,
                    WebNamespace
                ]).GetResult();

            //assert
            Assert.True(result.IsSuccessful);
        }

        [Fact]
        public void Application_Should_Not_HaveDependencyOnOtherProjects()
        {
            //act
            var result = Types.InCurrentDomain()
                .That()
                .ResideInNamespace(ApplicationNamespace)
                .ShouldNot()
                .HaveDependencyOnAny([
                    InfrastructureNamespace,
                    PresentationNamespace,
                    WebNamespace
                ]).GetResult();

            //assert
            Assert.True(result.IsSuccessful);
        }

        [Fact]
        public void Infrastructure_Should_Not_HaveDependencyOnOtherProjects()
        {
            //act
            var result = Types.InCurrentDomain()
                .That()
                .ResideInNamespace(InfrastructureNamespace)
                .ShouldNot()
                .HaveDependencyOnAny([
                    PresentationNamespace,
                    WebNamespace
                ]).GetResult();

            //assert
            Assert.True(result.IsSuccessful);
        }

        [Fact]
        public void Presentation_Should_Not_HaveDependencyOnOtherProjects()
        {
            //act
            var result = Types.InCurrentDomain()
                .That()
                .ResideInNamespace(PresentationNamespace)
                .ShouldNot()
                .HaveDependencyOnAny([
                    InfrastructureNamespace,
                    WebNamespace
                ]).GetResult();

            //assert
            Assert.True(result.IsSuccessful);
        }

        [Fact]
        public void Web_Should_Not_HaveDependencyOnOtherProjects()
        {
            //act
            var result = Types.InCurrentDomain()
                .That()
                .ResideInNamespace(WebNamespace)
                .ShouldNot()
                .HaveDependencyOnAny([
                    DomainNamespace
                ]).GetResult();

            //assert
            Assert.True(result.IsSuccessful);
        }
    }
}