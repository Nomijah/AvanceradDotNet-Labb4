API requests ->

Get all persons: https://localhost:7211/api/Person

Get all interests for a person: https://localhost:7211/api/Person/Interests?id=3

Get all links for a person: https://localhost:7211/api/Person/Links?id=3

Add an interest to a person: https://localhost:7211/api/Interest/AddPerson?interestId=4&personId=2

Create new link connected to a person and an interest: https://localhost:7211/api/Link?title=Codecademy&url=https%3A%2F%2Fwww.codecademy.com&personId=2&interestId=4