package com.ankamagames.dofus.network.messages.game.inventory.items
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class LivingObjectMessageRequestMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6066;
       
      
      private var _isInitialized:Boolean = false;
      
      public var msgId:uint = 0;
      
      public var parameters:Vector.<String>;
      
      public var livingObject:uint = 0;
      
      private var _parameterstree:FuncTree;
      
      public function LivingObjectMessageRequestMessage()
      {
         this.parameters = new Vector.<String>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6066;
      }
      
      public function initLivingObjectMessageRequestMessage(param1:uint = 0, param2:Vector.<String> = null, param3:uint = 0) : LivingObjectMessageRequestMessage
      {
         this.msgId = param1;
         this.parameters = param2;
         this.livingObject = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.msgId = 0;
         this.parameters = new Vector.<String>();
         this.livingObject = 0;
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
         this.serializeAs_LivingObjectMessageRequestMessage(param1);
      }
      
      public function serializeAs_LivingObjectMessageRequestMessage(param1:ICustomDataOutput) : void
      {
         if(this.msgId < 0)
         {
            throw new Error("Forbidden value (" + this.msgId + ") on element msgId.");
         }
         param1.writeVarShort(this.msgId);
         param1.writeShort(this.parameters.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.parameters.length)
         {
            param1.writeUTF(this.parameters[_loc2_]);
            _loc2_++;
         }
         if(this.livingObject < 0)
         {
            throw new Error("Forbidden value (" + this.livingObject + ") on element livingObject.");
         }
         param1.writeVarInt(this.livingObject);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_LivingObjectMessageRequestMessage(param1);
      }
      
      public function deserializeAs_LivingObjectMessageRequestMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:String = null;
         this._msgIdFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readUTF();
            this.parameters.push(_loc4_);
            _loc3_++;
         }
         this._livingObjectFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_LivingObjectMessageRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_LivingObjectMessageRequestMessage(param1:FuncTree) : void
      {
         param1.addChild(this._msgIdFunc);
         this._parameterstree = param1.addChild(this._parameterstreeFunc);
         param1.addChild(this._livingObjectFunc);
      }
      
      private function _msgIdFunc(param1:ICustomDataInput) : void
      {
         this.msgId = param1.readVarUhShort();
         if(this.msgId < 0)
         {
            throw new Error("Forbidden value (" + this.msgId + ") on element of LivingObjectMessageRequestMessage.msgId.");
         }
      }
      
      private function _parameterstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._parameterstree.addChild(this._parametersFunc);
            _loc3_++;
         }
      }
      
      private function _parametersFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:String = param1.readUTF();
         this.parameters.push(_loc2_);
      }
      
      private function _livingObjectFunc(param1:ICustomDataInput) : void
      {
         this.livingObject = param1.readVarUhInt();
         if(this.livingObject < 0)
         {
            throw new Error("Forbidden value (" + this.livingObject + ") on element of LivingObjectMessageRequestMessage.livingObject.");
         }
      }
   }
}
