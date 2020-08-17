package com.ankamagames.dofus.network.messages.game.idol
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.BooleanByteWrapper;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class IdolSelectErrorMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6584;
       
      
      private var _isInitialized:Boolean = false;
      
      public var reason:uint = 0;
      
      public var idolId:uint = 0;
      
      public var activate:Boolean = false;
      
      public var party:Boolean = false;
      
      public function IdolSelectErrorMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6584;
      }
      
      public function initIdolSelectErrorMessage(param1:uint = 0, param2:uint = 0, param3:Boolean = false, param4:Boolean = false) : IdolSelectErrorMessage
      {
         this.reason = param1;
         this.idolId = param2;
         this.activate = param3;
         this.party = param4;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.reason = 0;
         this.idolId = 0;
         this.activate = false;
         this.party = false;
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
         this.serializeAs_IdolSelectErrorMessage(param1);
      }
      
      public function serializeAs_IdolSelectErrorMessage(param1:ICustomDataOutput) : void
      {
         var _loc2_:uint = 0;
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,0,this.activate);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,1,this.party);
         param1.writeByte(_loc2_);
         param1.writeByte(this.reason);
         if(this.idolId < 0)
         {
            throw new Error("Forbidden value (" + this.idolId + ") on element idolId.");
         }
         param1.writeVarShort(this.idolId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_IdolSelectErrorMessage(param1);
      }
      
      public function deserializeAs_IdolSelectErrorMessage(param1:ICustomDataInput) : void
      {
         this.deserializeByteBoxes(param1);
         this._reasonFunc(param1);
         this._idolIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_IdolSelectErrorMessage(param1);
      }
      
      public function deserializeAsyncAs_IdolSelectErrorMessage(param1:FuncTree) : void
      {
         param1.addChild(this.deserializeByteBoxes);
         param1.addChild(this._reasonFunc);
         param1.addChild(this._idolIdFunc);
      }
      
      private function deserializeByteBoxes(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readByte();
         this.activate = BooleanByteWrapper.getFlag(_loc2_,0);
         this.party = BooleanByteWrapper.getFlag(_loc2_,1);
      }
      
      private function _reasonFunc(param1:ICustomDataInput) : void
      {
         this.reason = param1.readByte();
         if(this.reason < 0)
         {
            throw new Error("Forbidden value (" + this.reason + ") on element of IdolSelectErrorMessage.reason.");
         }
      }
      
      private function _idolIdFunc(param1:ICustomDataInput) : void
      {
         this.idolId = param1.readVarUhShort();
         if(this.idolId < 0)
         {
            throw new Error("Forbidden value (" + this.idolId + ") on element of IdolSelectErrorMessage.idolId.");
         }
      }
   }
}
