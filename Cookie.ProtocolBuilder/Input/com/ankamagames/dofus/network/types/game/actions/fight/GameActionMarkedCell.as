package com.ankamagames.dofus.network.types.game.actions.fight
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class GameActionMarkedCell implements INetworkType
   {
      
      public static const protocolId:uint = 85;
       
      
      public var cellId:uint = 0;
      
      public var zoneSize:int = 0;
      
      public var cellColor:int = 0;
      
      public var cellsType:int = 0;
      
      public function GameActionMarkedCell()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 85;
      }
      
      public function initGameActionMarkedCell(param1:uint = 0, param2:int = 0, param3:int = 0, param4:int = 0) : GameActionMarkedCell
      {
         this.cellId = param1;
         this.zoneSize = param2;
         this.cellColor = param3;
         this.cellsType = param4;
         return this;
      }
      
      public function reset() : void
      {
         this.cellId = 0;
         this.zoneSize = 0;
         this.cellColor = 0;
         this.cellsType = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameActionMarkedCell(param1);
      }
      
      public function serializeAs_GameActionMarkedCell(param1:ICustomDataOutput) : void
      {
         if(this.cellId < 0 || this.cellId > 559)
         {
            throw new Error("Forbidden value (" + this.cellId + ") on element cellId.");
         }
         param1.writeVarShort(this.cellId);
         param1.writeByte(this.zoneSize);
         param1.writeInt(this.cellColor);
         param1.writeByte(this.cellsType);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameActionMarkedCell(param1);
      }
      
      public function deserializeAs_GameActionMarkedCell(param1:ICustomDataInput) : void
      {
         this._cellIdFunc(param1);
         this._zoneSizeFunc(param1);
         this._cellColorFunc(param1);
         this._cellsTypeFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameActionMarkedCell(param1);
      }
      
      public function deserializeAsyncAs_GameActionMarkedCell(param1:FuncTree) : void
      {
         param1.addChild(this._cellIdFunc);
         param1.addChild(this._zoneSizeFunc);
         param1.addChild(this._cellColorFunc);
         param1.addChild(this._cellsTypeFunc);
      }
      
      private function _cellIdFunc(param1:ICustomDataInput) : void
      {
         this.cellId = param1.readVarUhShort();
         if(this.cellId < 0 || this.cellId > 559)
         {
            throw new Error("Forbidden value (" + this.cellId + ") on element of GameActionMarkedCell.cellId.");
         }
      }
      
      private function _zoneSizeFunc(param1:ICustomDataInput) : void
      {
         this.zoneSize = param1.readByte();
      }
      
      private function _cellColorFunc(param1:ICustomDataInput) : void
      {
         this.cellColor = param1.readInt();
      }
      
      private function _cellsTypeFunc(param1:ICustomDataInput) : void
      {
         this.cellsType = param1.readByte();
      }
   }
}
