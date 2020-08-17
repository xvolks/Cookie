package com.ankamagames.dofus.network.types.game.data.items.effects
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class ObjectEffect implements INetworkType
   {
      
      public static const protocolId:uint = 76;
       
      
      public var actionId:uint = 0;
      
      public function ObjectEffect()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 76;
      }
      
      public function initObjectEffect(param1:uint = 0) : ObjectEffect
      {
         this.actionId = param1;
         return this;
      }
      
      public function reset() : void
      {
         this.actionId = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ObjectEffect(param1);
      }
      
      public function serializeAs_ObjectEffect(param1:ICustomDataOutput) : void
      {
         if(this.actionId < 0)
         {
            throw new Error("Forbidden value (" + this.actionId + ") on element actionId.");
         }
         param1.writeVarShort(this.actionId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ObjectEffect(param1);
      }
      
      public function deserializeAs_ObjectEffect(param1:ICustomDataInput) : void
      {
         this._actionIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ObjectEffect(param1);
      }
      
      public function deserializeAsyncAs_ObjectEffect(param1:FuncTree) : void
      {
         param1.addChild(this._actionIdFunc);
      }
      
      private function _actionIdFunc(param1:ICustomDataInput) : void
      {
         this.actionId = param1.readVarUhShort();
         if(this.actionId < 0)
         {
            throw new Error("Forbidden value (" + this.actionId + ") on element of ObjectEffect.actionId.");
         }
      }
   }
}
