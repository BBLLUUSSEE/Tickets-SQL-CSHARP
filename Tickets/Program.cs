using Tickets;

bool quit = false;
do
{
    Console.WriteLine($"===========MENU==========\n");
    Console.WriteLine("[1] - Elenco Tickets\n");
    Console.WriteLine("[2] - Aggiungi Ticket\n");
    Console.WriteLine("[3] - Elimina Ticket\n");
    Console.WriteLine("[q] - QUIT\n");

    string scelta = Console.ReadLine();
    switch (scelta)
    {
        case "1":
            //lista di tickets
            TicketsDemo.StampaInOrdineCronologico();
            break;
        case "2":
            //aggiungi ticket
            TicketsDemo.InsertConParametriDemo();
            break;
        case "3":
            //elimina ticket
            TicketsDemo.DeleteConParametriDemo();
            break;
        case "q":
            quit = true;
            break;
        default:
            Console.WriteLine("Comando sconosciuto");
            break;

    }
} while (!quit);