package com.ankamagames.dofus.network.messages.game.prism
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PrismUseRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6041;
       
      
      private var _isInitialized:Boolean = false;
      
      public var moduleToUse:uint = 0;
      
      public function PrismUseRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6041;
      }
      
      public function initPrismUseRequestMessage(param1:uint = 0) : PrismUseRequestMessage
      {
         this.moduleToUse = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.moduleToUse = 0;
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_PrismUseRequestMessage(param1);
      }
      
      public function serializeAs_PrismUseRequestMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.moduleToUse);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PrismUseRequestMessage(param1);
      }
      
      public function deserializeAs_PrismUseRequestMessage(param1:ICustomDataInput) : void
      {
         this._moduleToUseFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PrismUseRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_PrismUseRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._moduleToUseFunc);
      }
      
      private function _moduleToUseFunc(param1:ICustomDataInput) : void
      {
         this.moduleToUse = param1.readByte();
         if(this.moduleToUse < 0)
         {
            throw new Error("Forbidden value (" + this.moduleToUse + ") on element of PrismUseRequestMessage.moduleToUse.");
         }
      }
   }
}
