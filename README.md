# Cole's Pokedex! [Pokedex/PokemonRegistry]
.net core, elasticsearch and react-redux were used to create a full stack application for searching for pokemon in the pokedex (with the addition of trainer ID to make it many thousands of records)

![Horrible Photoshop Mess By Me... TBH](https://i.imgur.com/4Pc9ZXg.png)

# Usage:

Type a pokemon's name into the search bar, hit the button and then a bunch of search results should come up!

![Landing Page](https://i.imgur.com/Ivkq68Y.png)

![Search Executed](https://i.imgur.com/FAi6mZz.png)

Select a pokemon from the list and view it's details :) Unfortunately this is a little thinner than I had hoped it would be, was planning to use Nivo and have visualizations of all the stats. https://nivo.rocks/

![Pokemon Detail Check](https://i.imgur.com/sLS9Gwg.png)

Swagger docs are avaliable at https://localhost:5001/swagger/
![Swagger Docs](https://i.imgur.com/jPA2CEB.png)

# Installation:

I preferred to use CLI for installation of the various packages where possible.

Database:
1: Elastic Search.

Source: https://www.elastic.co/guide/en/elasticsearch/reference/current/getting-started-install.html

Followed installation instructions here.

2: NEST for ElasticSearch to .Net

Source: https://www.nuget.org/packages/NEST

Command: dotnet add package NEST --version 7.4.1

3: Swagger for clear API definitions / autodocs 

Source:  https://www.nuget.org/packages/Swashbuckle.AspNetCore/5.0.0-rc4

Command:  dotnet add package Swashbuckle.AspNetCore --version 5.0.0-rc4


4: Serilog for Logging to a File

Source: https://www.nuget.org/packages/serilog.extensions.logging.file

Command: dotnet add package Serilog.Extensions.Logging.File --version 1.1.0

Front End React/Redux Steps:

1: Installation of Node.js

I used this to retrieve all of the necessary installations to make this work.

Source: https://nodejs.org/en/

2: Installation of react-redux to help manage state of the front end.

Command: npm install --save redux react-redux


3: Installation of redux-thunk

Command: npm install --save redux-thunk

4: Hopefully that's all, when I was trying to install it on another machine these are the only ones that really stuck out as a problem.


# Startup:

1: Populate ElasticSearch DB with the test data.

With elasticsearch DB set up please run these commands:

Path: ElasticSearch/

Command 1: pip install elasticsearch-loader

(Pip will need python installed on the machine in general.)

Command 2: elasticsearch_loader --index pokemon --type pokemon csv PokemonData.csv


2: Starting up the Back End:

Please navigate to the path and then enter the command at path. This will start up the back end.

Path: BackEnd/

Command:  dotnet run


3: Starting up the Front End:

Please navigate to the path and then enter the command at path. This will start up the front end.

Path: FrontEnd/src/

Command: npm start


Might need to run this command if you’re getting errors with the front end startup... but hopefully not! 

Command: npm i -g react-scripts

*The frontend does assume your backend is running on "http://localhost:5001" But this can be modified if the backend is on a different port in the “streams.js” file.

*The backend does assumme your elasticsearch is running on "http://http://localhost:9200". This can be modified from the appsettings.json file.

4: CORS tools must be activated. I personally mostly use Chrome and I used this tool during the development and testing of this app. Otherwise the Front End API will fail to communicate with the Back End API.

Source: https://chrome.google.com/webstore/detail/allow-cors-access-control/lhobafahddgcelffkeicbaginigeejlf?hl=en

# Choices / Reasoning:

1: I chose ElasticSearch over the other options provided as ElasticSearch provided quite extensive documentation on their website ranging from their get started guide to the introduction to their DSL. ElasticSearch also was stated to be built ontop of Lucene and gives a more convenient abstraction through a JSON based REST API, tools like Kibana and a large developer support network when needed. Also ElasticSearch provides the NEST DSL to combine .net and ElasticSearch together that seems to me as being very clean, clear, concise and fun to use.

Source 1: https://www.elastic.co/guide/en/elasticsearch/reference/current/getting-started-install.html

Source 2:
https://www.elastic.co/guide/en/elasticsearch/reference/5.5/_introducing_the_query_language.html

Source 3: https://www.elastic.co/products/kibana

2: NEST was a strongly typed DSL suggested to be used to make .net core work with elasticsearch. I figured that using a more grounded packaged-and-proven approach would be vastly superior to me putting together my own JSON Requests.

Source:   
https://www.elastic.co/guide/en/elasticsearch/client/net-api/current/nest-getting-started.html

3: Swagger is something I’ve used in the past and I found the way that it automatically generates API information very convenient and nice and clear. While the API is very small for this project I think it’s a nice practice. 

Source 1: https://swagger.io/

Source 2: https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.0&tabs=netcore-cli



# Data Obtained From

The Complete Pokemon Dataset on Kaggle. (Doesn’t have Sword/Shield update however.)
A few columns were removed from the final CSV file because they were out of scope for this project.

Source:https://www.kaggle.com/rounakbanik/pokemon


# A Few Bugs I Wasn’t Able To Catch In Time
1: The pip script that would import the CSV file into ElasticSearch unfortunately would put the: “∩╗┐” characters before “attack” which parsed incorrectly in my application and wasn’t read by my system. This ultimately resulted in all attack values being equal to 0 in the system. I tried a few alternatives and ran into a host of other issues and some became very involved so I decided to stick with this one but note the bug.

2: There is an additional empty item added onto the list that shouldn't be. 

# A Few Things I Would Like to Add In The Future:
1: Unit Testing. Unfortunately things got very hairy with some of the errors. Unit testing however is a massively high priority to me but due to the nature of learning elasticsearch from the ground up, relearning and expanding my .netcore skillset and making everything smooth this did fall off. Something I'd never ever ever do given the choice. But this week was extremely tight on time for me ... :( 

Likewise integration testing and E2E testing falls under this umbrella as well.

2: Much better detail screen for the pokemon stats. I was looking at using the Nivo library that I've used extensively in past work for that. https://nivo.rocks/

3: Spinner during the API call on the search bar.

4: Actual images of the pokemon on the side in large for the detail screen, small sprites for the search list. 

5: Repository pattern implemented for the elasticsearch DB.

6: All of the additional features listed in the email.

# Pokemon is owned by Gamefreak and Nintendo and I in no way shape or form own the pokemon images, pokemon data and this is purely for demonstration purposes!
