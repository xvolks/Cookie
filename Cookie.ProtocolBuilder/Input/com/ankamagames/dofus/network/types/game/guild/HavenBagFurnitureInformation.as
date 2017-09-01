package com.ankamagames.dofus.network.types.game.guild
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class HavenBagFurnitureInformation implements INetworkType
   {
      
      public static const protocolId:uint = 498;
       
      
      public var cellId:uint = 0;
      
      public var funitureId:int = 0;
      
      public var orientation:uint = 0;
      
      public function HavenBagFurnitureInformation()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 498;
      }
      
      public function initHavenBagFurnitureInformation(param1:uint = 0, param2:int = 0, param3:uint = 0) : HavenBagFurnitureInformation
      {
         this.cellId = param1;
         this.funitureId = param2;
         this.orientation = param3;
         return this;
      }
      
      public function reset() : void
      {
         this.cellId = 0;
         this.funitureId = 0;
         this.orientation = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_HavenBagFurnitureInformation(param1);
      }
      
      public function serializeAs_HavenBagFurnitureInformation(param1:ICustomDataOutput) : void
      {
         if(this.cellId < 0)
         {
            throw new Error("Forbidden value (" + this.cellId + ") on element cellId.");
         }
         param1.writeVarShort(this.cellId);
         param1.writeInt(this.funitureId);
         if(this.orientation < 0)
         {
            throw new Error("Forbidden value (" + this.orientation + ") on element orientation.");
         }
         param1.writeByte(this.orientation);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HavenBagFurnitureInformation(param1);
      }
      
      public function deserializeAs_HavenBagFurnitureInformation(param1:ICustomDataInput) : void
      {
         this._cellIdFunc(param1);
         this._funitureIdFunc(param1);
         this._orientationFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HavenBagFurnitureInformation(param1);
      }
      
      public function deserializeAsyncAs_HavenBagFurnitureInformation(param1:FuncTree) : void
      {
         param1.addChild(this._cellIdFunc);
         param1.addChild(this._funitureIdFunc);
         param1.addChild(this._orientationFunc);
      }
      
      private function _cellIdFunc(param1:ICustomDataInput) : void
      {
         this.cellId = param1.readVarUhShort();
         if(this.cellId < 0)
         {
            throw new Error("Forbidden value (" + this.cellId + ") on element of HavenBagFurnitureInformation.cellId.");
         }
      }
      
      private function _funitureIdFunc(param1:ICustomDataInput) : void
      {
         this.funitureId = param1.readInt();
      }
      
      private function _orientationFunc(param1:ICustomDataInput) : void
      {
         this.orientation = param1.readByte();
         if(this.orientation < 0)
         {
            throw new Error("Forbidden value (" + this.orientation + ") on element of HavenBagFurnitureInformation.orientation.");
         }
      }
   }
}
