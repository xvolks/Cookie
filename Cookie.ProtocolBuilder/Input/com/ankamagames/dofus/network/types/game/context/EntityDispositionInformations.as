package com.ankamagames.dofus.network.types.game.context
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class EntityDispositionInformations implements INetworkType
   {
      
      public static const protocolId:uint = 60;
       
      
      public var cellId:int = 0;
      
      public var direction:uint = 1;
      
      public function EntityDispositionInformations()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 60;
      }
      
      public function initEntityDispositionInformations(param1:int = 0, param2:uint = 1) : EntityDispositionInformations
      {
         this.cellId = param1;
         this.direction = param2;
         return this;
      }
      
      public function reset() : void
      {
         this.cellId = 0;
         this.direction = 1;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_EntityDispositionInformations(param1);
      }
      
      public function serializeAs_EntityDispositionInformations(param1:ICustomDataOutput) : void
      {
         if(this.cellId < -1 || this.cellId > 559)
         {
            throw new Error("Forbidden value (" + this.cellId + ") on element cellId.");
         }
         param1.writeShort(this.cellId);
         param1.writeByte(this.direction);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_EntityDispositionInformations(param1);
      }
      
      public function deserializeAs_EntityDispositionInformations(param1:ICustomDataInput) : void
      {
         this._cellIdFunc(param1);
         this._directionFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_EntityDispositionInformations(param1);
      }
      
      public function deserializeAsyncAs_EntityDispositionInformations(param1:FuncTree) : void
      {
         param1.addChild(this._cellIdFunc);
         param1.addChild(this._directionFunc);
      }
      
      private function _cellIdFunc(param1:ICustomDataInput) : void
      {
         this.cellId = param1.readShort();
         if(this.cellId < -1 || this.cellId > 559)
         {
            throw new Error("Forbidden value (" + this.cellId + ") on element of EntityDispositionInformations.cellId.");
         }
      }
      
      private function _directionFunc(param1:ICustomDataInput) : void
      {
         this.direction = param1.readByte();
         if(this.direction < 0)
         {
            throw new Error("Forbidden value (" + this.direction + ") on element of EntityDispositionInformations.direction.");
         }
      }
   }
}
