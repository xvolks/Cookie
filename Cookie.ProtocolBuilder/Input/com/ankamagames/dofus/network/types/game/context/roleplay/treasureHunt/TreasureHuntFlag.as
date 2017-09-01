package com.ankamagames.dofus.network.types.game.context.roleplay.treasureHunt
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class TreasureHuntFlag implements INetworkType
   {
      
      public static const protocolId:uint = 473;
       
      
      public var mapId:int = 0;
      
      public var state:uint = 0;
      
      public function TreasureHuntFlag()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 473;
      }
      
      public function initTreasureHuntFlag(param1:int = 0, param2:uint = 0) : TreasureHuntFlag
      {
         this.mapId = param1;
         this.state = param2;
         return this;
      }
      
      public function reset() : void
      {
         this.mapId = 0;
         this.state = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_TreasureHuntFlag(param1);
      }
      
      public function serializeAs_TreasureHuntFlag(param1:ICustomDataOutput) : void
      {
         param1.writeInt(this.mapId);
         param1.writeByte(this.state);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_TreasureHuntFlag(param1);
      }
      
      public function deserializeAs_TreasureHuntFlag(param1:ICustomDataInput) : void
      {
         this._mapIdFunc(param1);
         this._stateFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_TreasureHuntFlag(param1);
      }
      
      public function deserializeAsyncAs_TreasureHuntFlag(param1:FuncTree) : void
      {
         param1.addChild(this._mapIdFunc);
         param1.addChild(this._stateFunc);
      }
      
      private function _mapIdFunc(param1:ICustomDataInput) : void
      {
         this.mapId = param1.readInt();
      }
      
      private function _stateFunc(param1:ICustomDataInput) : void
      {
         this.state = param1.readByte();
         if(this.state < 0)
         {
            throw new Error("Forbidden value (" + this.state + ") on element of TreasureHuntFlag.state.");
         }
      }
   }
}
