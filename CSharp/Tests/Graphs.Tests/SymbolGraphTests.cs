using System;
using FluentAssertions;
using Kayllian.Algorithms.Graphs;
using Xunit;

namespace Graphs.Tests
{
    public class SymbolGraphTests
    {
        private static SymbolGraph Create()
        {
            var lines = new[]
            {
                "Ali: An American Hero (2000)/Boen, Earl/Cassidy, Martin/Coddette, Marc/Curtis-Hall, Vondie/Danon, Leslie/Doty, David/Ernest, King/Fargas, Antonio/Ferrero, Martin/Gerber, Jay/Gethers, Amani/Kain, Khalil/Lala, Joe/Marotta, Rich/Meeks, Aaron/Morton, Joe/Pugsley, Don/Ramsey, David/Smallwood, Vivian/Smith, Ebonie/Stevens, Joy/Ward, James Kevin/Washington, Jascha/Williams III, Clarence/Williams III, Joe",
                "Almost a Heroine (1916)/Melville, Rose",
                "Almost Heroes (1998)/Aguilar, George/Anderson, Scott/Andersson, Kris/Arquette, Lewis/Barbuscia, Lisa/Barrera, David/Camp, Hamilton/Clemenson, Christian/Cover, Franklin/Cranshaw, Patrick/Cruz, Gregory Norman/Daydoge, Billy/DeKay, Tim/Del Sherman, Barry/Dunn, Kevin/Farley, Chris/Farley, John/Hart, Gordon/Hinkley, Brent/Hopkins, T. Dan/Joss, Jonathan/Lacopo, Jay/Lake, Don/Levy, Eugene/Lindgren, Axel/Packer, David/Passer, Daniel/Perry, Matthew/Porter, Steven M./Salsedo, Frank/Sellon-Wright, Keith/Shearer, Harry/Tittor, Robert/Williamson, Scott/Woodbine, Bokeem",
                "America: A Tribute to Heroes(2001)/ Ali, Muhammad/Berry, Halle/Bon Jovi, Jon/Bono/Borland, Wes/Brenneman, Amy/Campbell, Mike/Carey, Mariah/Carrey, Jim/Clayton, Adam/Clooney, George/Crow, Sheryl/Cruise, Tom/Cruz, Penélope/Cusack, John/De Niro, Robert/DeVito, Danny/Del Toro, Benicio/Diaz, Cameron/Dion, Céline/Durst, Fred/Eastwood, Clint/Epstein, Howie/Field, Sally/Flockhart, Calista/Franz, Dennis/Garcia, Andy/Goldberg, Whoopi/Gooding Jr., Cuba/Grammer, Kelsey/Hanks, Tom/Hawn, Goldie/Hayek, Salma/Hill, Faith/Iglesias, Enrique/Jagger, Mick/Jean, Wyclef/Joel, Billy/Kaczmarek, Jane/Keaton, Michael/Keys, Alicia/Liu, Lucy/Matthews, Dave/McCready, Mike/McEntire, Reba/Mullen Jr., Larry/Myers, Mike/Nelson, Willie/Nicholson, Jack/O'Brien, Conan/Pacino, Al/Parker, Sarah Jessica/Petty, Tom/Pitt, Brad/Roberts, Julia/Rock, Chris/Romano, Ray/Russell, Kurt/Ryan, Meg/Rzeznik, Johnny/Sambora, Richie/Sandler, Adam/Shaffer, Paul/Simon, Paul/Smith, Will/Smits, Jimmy/Springsteen, Bruce/Stallone, Sylvester/Stiller, Ben/Sting/Taylor, Christine/The Edge/Vedder, Eddie/Wahlberg, Mark/Ward, Sela/Williams, Robin/Wonder, Stevie/Woods, James/Young, Neil",
                "American Hero(1997)/Thomas, Patrick",
                "American Hero: The Michael Jordan Story(1998)/ Nowack, Johan-Carl",
                "Andy Plays Hero(1914)/Clark, Andy",
                "Anti-hero(1999)/Arndt, Mark/Bramwell, Dave/Cooper, Isaac/Sheppard, Steve/Smith, Craig/Tjersland, Todd",
                "Arnold Schwarzenegger: Hollywood Hero(1999)/ Andrews, Nigel/Arnold, Tom/Belushi, James/Bernstein, Armyan/Biehn, Michael/Coburn, James/David, Keith/Hall, Douglas Kent/ Hyams, Peter/Miller, Penelope Ann/ Morris, Eric/Reitman, Ivan/Schlierkamp, Gunter/Schwarzenegger, Arnold/Shriver, Sargent/Weider, Joe"
            };

            return new SymbolGraph(lines, "/");
        }

        [Theory]
        [InlineData("Cassidy, Martin")]
        [InlineData("America: A Tribute to Heroes(2001)")]
        public void ContainShould_ReturnTrue_GivenNodeExists(string key)
        {
            // Arrange
            var graph = Create();

            // Act
            var contains = graph.Contains(key);

            // Assert
            contains.Should().BeTrue();
        }

        [Fact]
        public void ContainsShould_ReturnFalse_GivenKeyDoesNotExist()
        {
            // Arrange
            var key = Guid.NewGuid().ToString("N");
            var graph = Create();

            // Act
            var contains = graph.Contains(key);

            // Assert
            contains.Should().BeFalse();
        }

        [Fact]
        public void IndexAndNameShould_BeRecipical_GivenKeyExists()
        {
            // Arrange
            const string key = "Schwarzenegger, Arnold";
            var graph = Create();

            // Act
            var index = graph.Index(key);
            var name = graph.Name(index);

            // Assert
            name.Should().Be(key);
        }
    }
}
