package com.ankamagames.dofus.network.messages.updater.parts
{
   import com.ankamagames.dofus.network.types.updater.ContentPart;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PartsListMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 1502;
       
      
      private var _isInitialized:Boolean = false;
      
      public var parts:Vector.<ContentPart>;
      
      private var _partstree:FuncTree;
      
      public function PartsListMessage()
      {
         this.parts = new Vector.<ContentPart>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 1502;
      }
      
      public function initPartsListMessage(param1:Vector.<ContentPart> = null) : PartsListMessage
      {
         this.parts = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.parts = new Vector.<ContentPart>();
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
         this.serializeAs_PartsListMessage(param1);
      }
      
      public function serializeAs_PartsListMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.parts.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.parts.length)
         {
            (this.parts[_loc2_] as ContentPart).serializeAs_ContentPart(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PartsListMessage(param1);
      }
      
      public function deserializeAs_PartsListMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:ContentPart = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new ContentPart();
            _loc4_.deserialize(param1);
            this.parts.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PartsListMessage(param1);
      }
      
      public function deserializeAsyncAs_PartsListMessage(param1:FuncTree) : void
      {
         this._partstree = param1.addChild(this._partstreeFunc);
      }
      
      private function _partstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._partstree.addChild(this._partsFunc);
            _loc3_++;
         }
      }
      
      private function _partsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:ContentPart = new ContentPart();
         _loc2_.deserialize(param1);
         this.parts.push(_loc2_);
      }
   }
}
