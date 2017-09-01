package com.ankamagames.dofus.network.types.game.approach
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class ServerSessionConstantInteger extends ServerSessionConstant implements INetworkType
   {
      
      public static const protocolId:uint = 433;
       
      
      public var value:int = 0;
      
      public function ServerSessionConstantInteger()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 433;
      }
      
      public function initServerSessionConstantInteger(param1:uint = 0, param2:int = 0) : ServerSessionConstantInteger
      {
         super.initServerSessionConstant(param1);
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
         this.serializeAs_ServerSessionConstantInteger(param1);
      }
      
      public function serializeAs_ServerSessionConstantInteger(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ServerSessionConstant(param1);
         param1.writeInt(this.value);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ServerSessionConstantInteger(param1);
      }
      
      public function deserializeAs_ServerSessionConstantInteger(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._valueFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ServerSessionConstantInteger(param1);
      }
      
      public function deserializeAsyncAs_ServerSessionConstantInteger(param1:FuncTree) : void
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
