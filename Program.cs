using Bankautomat.Controllers;
using Bankautomat.Services;
using Bankautomat.Storage;
using Bankautomat.Interfaces;

IStorage storage = new JsonStorage();
IBankService bankService = new BankService(storage);
IInterestService interestService = new InterestService();

var controller = new BankController(bankService, interestService);

controller.Run();