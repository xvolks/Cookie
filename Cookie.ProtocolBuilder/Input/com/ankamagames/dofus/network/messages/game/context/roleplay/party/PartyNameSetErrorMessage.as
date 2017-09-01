package com.ankamagames.dofus.network.messages.game.context.roleplay.party
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PartyNameSetErrorMessage extends AbstractPartyMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6501;
       
      
      private var _isInitialized:Boolean = false;
      
      public var result:uint = 0;
      
      public function PartyNameSetErrorMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6501;
      }
      
      public function initPartyNameSetErrorMessage(param1:uint = 0, param2:uint = 0) : PartyNameSetErrorMessage
      {
         super.initAbstractPartyMessage(param1);
         this.result = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.result = 0;
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
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_PartyNameSetErrorMessage(param1);
      }
      
      public function serializeAs_PartyNameSetErrorMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractPartyMessage(param1);
         param1.writeByte(this.result);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PartyNameSetErrorMessage(param1);
      }
      
      public function deserializeAs_PartyNameSetErrorMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._resultFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PartyNameSetErrorMessage(param1);
      }
      
      public function deserializeAsyncAs_PartyNameSetErrorMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._resultFunc);
      }
      
      private function _resultFunc(param1:ICustomDataInput) : void
      {
         this.result = param1.readByte();
         if(this.result < 0)
         {
            throw new Error("Forbidden value (" + this.result + ") on element of PartyNameSetErrorMessage.result.");
         }
      }
   }
}
