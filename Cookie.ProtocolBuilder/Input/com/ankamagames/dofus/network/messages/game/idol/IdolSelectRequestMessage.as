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
   public class IdolSelectRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6587;
       
      
      private var _isInitialized:Boolean = false;
      
      public var idolId:uint = 0;
      
      public var activate:Boolean = false;
      
      public var party:Boolean = false;
      
      public function IdolSelectRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6587;
      }
      
      public function initIdolSelectRequestMessage(param1:uint = 0, param2:Boolean = false, param3:Boolean = false) : IdolSelectRequestMessage
      {
         this.idolId = param1;
         this.activate = param2;
         this.party = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
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
         this.serializeAs_IdolSelectRequestMessage(param1);
      }
      
      public function serializeAs_IdolSelectRequestMessage(param1:ICustomDataOutput) : void
      {
         var _loc2_:uint = 0;
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,0,this.activate);
         _loc2_ = BooleanByteWrapper.setFlag(_loc2_,1,this.party);
         param1.writeByte(_loc2_);
         if(this.idolId < 0)
         {
            throw new Error("Forbidden value (" + this.idolId + ") on element idolId.");
         }
         param1.writeVarShort(this.idolId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_IdolSelectRequestMessage(param1);
      }
      
      public function deserializeAs_IdolSelectRequestMessage(param1:ICustomDataInput) : void
      {
         this.deserializeByteBoxes(param1);
         this._idolIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_IdolSelectRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_IdolSelectRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this.deserializeByteBoxes);
         param1.addChild(this._idolIdFunc);
      }
      
      private function deserializeByteBoxes(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readByte();
         this.activate = BooleanByteWrapper.getFlag(_loc2_,0);
         this.party = BooleanByteWrapper.getFlag(_loc2_,1);
      }
      
      private function _idolIdFunc(param1:ICustomDataInput) : void
      {
         this.idolId = param1.readVarUhShort();
         if(this.idolId < 0)
         {
            throw new Error("Forbidden value (" + this.idolId + ") on element of IdolSelectRequestMessage.idolId.");
         }
      }
   }
}
