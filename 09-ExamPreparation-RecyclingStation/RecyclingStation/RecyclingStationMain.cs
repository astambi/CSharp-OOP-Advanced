using RecyclingStation.BusinessLayer.Contracts.Core;
using RecyclingStation.BusinessLayer.Contracts.Factories;
using RecyclingStation.BusinessLayer.Contracts.IO;
using RecyclingStation.BusinessLayer.Core;
using RecyclingStation.BusinessLayer.Entities.Factories;
using RecyclingStation.BusinessLayer.IO;
using RecyclingStation.WasteDisposal;
using RecyclingStation.WasteDisposal.Interfaces;
using System;
using System.Collections.Generic;

namespace RecyclingStation
{
    public class RecyclingStationMain
    {
        private static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IStrategyHolder strategyHolder = new StrategyHolder(new Dictionary<Type, IGarbageDisposalStrategy>());
            IGarbageProcessor garbageProcessor = new GarbageProcessor(strategyHolder);
            IWasteFactory wasteFactory = new WasteFactory();
            IRecyclingStation recyclingStation = new RecyclingManager(garbageProcessor, wasteFactory);

            IEngine engine = new Engine(reader, writer, recyclingStation);
            engine.Run();
        }
    }
}
