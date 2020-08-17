package com.ankamagames.dofus.network.types.game.context.roleplay.fight.arena
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class ArenaRankInfos implements INetworkType
   {
      
      public static const protocolId:uint = 499;
       
      
      public var rank:uint = 0;
      
      public var bestRank:uint = 0;
      
      public var victoryCount:uint = 0;
      
      public var fightcount:uint = 0;
      
      public function ArenaRankInfos()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 499;
      }
      
      public function initArenaRankInfos(param1:uint = 0, param2:uint = 0, param3:uint = 0, param4:uint = 0) : ArenaRankInfos
      {
         this.rank = param1;
         this.bestRank = param2;
         this.victoryCount = param3;
         this.fightcount = param4;
         return this;
      }
      
      public function reset() : void
      {
         this.rank = 0;
         this.bestRank = 0;
         this.victoryCount = 0;
         this.fightcount = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ArenaRankInfos(param1);
      }
      
      public function serializeAs_ArenaRankInfos(param1:ICustomDataOutput) : void
      {
         if(this.rank < 0 || this.rank > 20000)
         {
            throw new Error("Forbidden value (" + this.rank + ") on element rank.");
         }
         param1.writeVarShort(this.rank);
         if(this.bestRank < 0 || this.bestRank > 20000)
         {
            throw new Error("Forbidden value (" + this.bestRank + ") on element bestRank.");
         }
         param1.writeVarShort(this.bestRank);
         if(this.victoryCount < 0)
         {
            throw new Error("Forbidden value (" + this.victoryCount + ") on element victoryCount.");
         }
         param1.writeVarShort(this.victoryCount);
         if(this.fightcount < 0)
         {
            throw new Error("Forbidden value (" + this.fightcount + ") on element fightcount.");
         }
         param1.writeVarShort(this.fightcount);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ArenaRankInfos(param1);
      }
      
      public function deserializeAs_ArenaRankInfos(param1:ICustomDataInput) : void
      {
         this._rankFunc(param1);
         this._bestRankFunc(param1);
         this._victoryCountFunc(param1);
         this._fightcountFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ArenaRankInfos(param1);
      }
      
      public function deserializeAsyncAs_ArenaRankInfos(param1:FuncTree) : void
      {
         param1.addChild(this._rankFunc);
         param1.addChild(this._bestRankFunc);
         param1.addChild(this._victoryCountFunc);
         param1.addChild(this._fightcountFunc);
      }
      
      private function _rankFunc(param1:ICustomDataInput) : void
      {
         this.rank = param1.readVarUhShort();
         if(this.rank < 0 || this.rank > 20000)
         {
            throw new Error("Forbidden value (" + this.rank + ") on element of ArenaRankInfos.rank.");
         }
      }
      
      private function _bestRankFunc(param1:ICustomDataInput) : void
      {
         this.bestRank = param1.readVarUhShort();
         if(this.bestRank < 0 || this.bestRank > 20000)
         {
            throw new Error("Forbidden value (" + this.bestRank + ") on element of ArenaRankInfos.bestRank.");
         }
      }
      
      private function _victoryCountFunc(param1:ICustomDataInput) : void
      {
         this.victoryCount = param1.readVarUhShort();
         if(this.victoryCount < 0)
         {
            throw new Error("Forbidden value (" + this.victoryCount + ") on element of ArenaRankInfos.victoryCount.");
         }
      }
      
      private function _fightcountFunc(param1:ICustomDataInput) : void
      {
         this.fightcount = param1.readVarUhShort();
         if(this.fightcount < 0)
         {
            throw new Error("Forbidden value (" + this.fightcount + ") on element of ArenaRankInfos.fightcount.");
         }
      }
   }
}
