package com.ankamagames.dofus.network.types.game.mount
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class UpdateMountIntBoost extends UpdateMountBoost implements INetworkType
   {
      
      public static const protocolId:uint = 357;
       
      
      public var value:int = 0;
      
      public function UpdateMountIntBoost()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 357;
      }
      
      public function initUpdateMountIntBoost(param1:uint = 0, param2:int = 0) : UpdateMountIntBoost
      {
         super.initUpdateMountBoost(param1);
         this.value = param2;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.value = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_UpdateMountIntBoost(param1);
      }
      
      public function serializeAs_UpdateMountIntBoost(param1:ICustomDataOutput) : void
      {
         super.serializeAs_UpdateMountBoost(param1);
         param1.writeInt(this.value);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_UpdateMountIntBoost(param1);
      }
      
      public function deserializeAs_UpdateMountIntBoost(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._valueFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_UpdateMountIntBoost(param1);
      }
      
      public function deserializeAsyncAs_UpdateMountIntBoost(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._valueFunc);
      }
      
      private function _valueFunc(param1:ICustomDataInput) : void
      {
         this.value = param1.readInt();
      }
   }
}
