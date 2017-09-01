package com.ankamagames.dofus.network.types.game.context
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class IdentifiedEntityDispositionInformations extends EntityDispositionInformations implements INetworkType
   {
      
      public static const protocolId:uint = 107;
       
      
      public var id:Number = 0;
      
      public function IdentifiedEntityDispositionInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 107;
      }
      
      public function initIdentifiedEntityDispositionInformations(param1:int = 0, param2:uint = 1, param3:Number = 0) : IdentifiedEntityDispositionInformations
      {
         super.initEntityDispositionInformations(param1,param2);
         this.id = param3;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.id = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_IdentifiedEntityDispositionInformations(param1);
      }
      
      public function serializeAs_IdentifiedEntityDispositionInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_EntityDispositionInformations(param1);
         if(this.id < -9007199254740990 || this.id > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.id + ") on element id.");
         }
         param1.writeDouble(this.id);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_IdentifiedEntityDispositionInformations(param1);
      }
      
      public function deserializeAs_IdentifiedEntityDispositionInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._idFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_IdentifiedEntityDispositionInformations(param1);
      }
      
      public function deserializeAsyncAs_IdentifiedEntityDispositionInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._idFunc);
      }
      
      private function _idFunc(param1:ICustomDataInput) : void
      {
         this.id = param1.readDouble();
         if(this.id < -9007199254740990 || this.id > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.id + ") on element of IdentifiedEntityDispositionInformations.id.");
         }
      }
   }
}
