# 3rdSemesterTrialExam
3rd Semester trial exam

## Opgave 5 Http teori
Opgavenbeskrivelse: 
Du skal lave en kort tekst note med nogle stikord
- a Giv en kort beskrivelse af HTTP protokelen
- b Giv en kort beskrivelse af de relevante HTTP statuskoder
- c Giv en kort beskrivelse af hvorledes REST bruger HTTP protokollen, herunder CRUD og adressering af ressourcer

### Hvad er HTTP
HTTP står for HyperText Transfer Protocol.
HTTP er en tekstbaseret protokol, der bruges til at overføre data (i form af tekst) over netværk.
Det er en del af TCP/IP-protokolsuiten, der bruges af bl.a. browsere og servere. 
HTTP er en stateless protokol, hvilket betyder, at hver forespørgsel er uafhængig af andre forespørgsler. 
Dette betyder, at hver forespørgsel fra en klient til en server er uafhængig af andre forespørgsler.

### HTTP statuskoder
Overordenet set er der 5 forskellige kategorier af statuskoder:
1xx: Informational - Anmodningen er modtaget, og processen fortsætter.
2xx: Success - Anmodningen er modtaget, forstået og accepteret.
3xx: Redirection - Yderligere handling er nødvendig for at fuldføre anmodningen.
4xx: Client Error - Anmodningen indeholder en fejl eller kan ikke behandles.
5xx: Server Error - Serveren mislykkedes i at opfylde en gyldig anmodning.

### REST og HTTP
REpresentational State Transfer (REST) er en arkitektur, der bruger HTTP-protokollen til at overføre data.
Anvender man REST med HTTP til fx en API, kan man beskrive API'en som RESTful.
Ved at brug REST med HTTP kan man udnytte de forskellige HTTP-metoder til at udføre CRUD-operationer på ressourcer.
Det kan fx være, at man vha. GET kan få informationer fra en API eller med POST kan oprette en ny ressource - e.g. et WoodPellet objekt i den her opgave.

