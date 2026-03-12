using Bankautomat.Services;
using Bankautomat.Storage;
using Bankautomat.Interfaces;
using Bankautomat.Controllers;

IStorage storage = new JsonStorage();
IBankService bankService = new BankService(storage);
IInterestService interestService = new InterestService();

var controller = new BankController(bankService, interestService);

controller.Run();