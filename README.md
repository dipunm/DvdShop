Requirements:
    - Modelling a DVD rental system.
    - We have 10 DVD's and of each, a variable number of copies
    - When a DVD is rented, it is marked as unavailable,
    - When a user wants to rent a DVD, they will first need to see
        its availability.

    - Database:
        | MovieId | Title | RRPrice | IMDBId
        (1, Tango & Cash, $5.99, B86J9)
        (2, Rachet & Clank, $15.99, Z34P9)
        (3, Back To The Future, $13.99, Q00L3)
        
        | DvdId | MovieId | Condition | User |
        (1, 1, 10, null)
        (2, 1, 9, null)
        (3, 1, 4, null)
        (4, 1, 10, Bob Barker)
        (5, 2, 9, Amie Littlefield)
        (6, 2, 9, Jack Smith)
        (7, 3, 7, null)
        (8, 3, 10, null)
        (9, 3, 8, William Kent)

    - First feature: As a user, I want to see a list of DVD's available.
        - The dvd's must have, title, image and rrprice

    - Turns out that we don't store images, so we need to use an
        IMDB API to fetch it using the IMDBId.
