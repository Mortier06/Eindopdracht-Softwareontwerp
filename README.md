# Weer App
Deze app genereerd een weerbericht op basis van 4 mogelijke metingen, luchtdruk, neerslag,... . er zijn in totaal 12 steden waar er een meting word uitgevoerd

# build run en test instructies

1. open een terminal in de hoofdmap van het project
2. Voer uit "dotnet build"
3. start het door "dotnet run" uit te voeren
4. API draait op  "http://localhost:5008"


# Issues

Het eerste probleem dat ik had was weten hoe ik er moest aan beginnen.

Wist niet wat een ...dto was, DI en hoe een api in elkaar zit.

Zag ook maar 3 steden zitten in het steden bestand dus heb ze gekopieerd van iemand anders.
Observable pattern wist ik al omdat mijn presentatie daarover ging.

Wist niet hoe ik zaken wegschreef naar een .json of .xml file. Heb dat uitgezogt aan de hand van youtube en chatgpt.
het programma werkte wel maar het schreef niet weg naar de bestanden, kwam er paar uur later achter dat het kwam doordat de weerstation klasse de list van observers niet goed bijhield. Heb dat opgelost door alles te laten subscriben in de program klasse.

Wist niet wat dto was dus had dat voor het laaste gehouden en was gelukt.

Had het moeilijk met alles bijhouden en weten waar wat moest staan, aangezien ik nog nooit gewerkt heb met zo een structuur. wel iets dichtbij. 

# Klassendiagram zie bestand boven
