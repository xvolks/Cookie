package com.ankamagames.dofus.network.messages.game.context.roleplay.havenbag
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class HavenBagPackListMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6620;
       
      
      private var _isInitialized:Boolean = false;
      
      public var packIds:Vector.<int>;
      
      private var _packIdstree:FuncTree;
      
      public function HavenBagPackListMessage()
      {
         this.packIds = new Vector.<int>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6620;
      }
      
      public function initHavenBagPackListMessage(param1:Vector.<int> = null) : HavenBagPackListMessage
      {
         this.packIds = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.packIds = new Vector.<int>();
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
         this.serializeAs_HavenBagPackListMessage(param1);
      }
      
      public function serializeAs_HavenBagPackListMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.packIds.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.packIds.length)
         {
            param1.writeByte(this.packIds[_loc2_]);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HavenBagPackListMessage(param1);
      }
      
      public function deserializeAs_HavenBagPackListMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:int = 0;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readByte();
            this.packIds.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HavenBagPackListMessage(param1);
      }
      
      public function deserializeAsyncAs_HavenBagPackListMessage(param1:FuncTree) : void
      {
         this._packIdstree = param1.addChild(this._packIdstreeFunc);
      }
      
      private function _packIdstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._packIdstree.addChild(this._packIdsFunc);
            _loc3_++;
         }
      }
      
      private function _packIdsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:int = param1.readByte();
         this.packIds.push(_loc2_);
      }
   }
}
