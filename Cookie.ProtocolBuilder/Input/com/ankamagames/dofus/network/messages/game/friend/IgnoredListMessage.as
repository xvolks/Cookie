package com.ankamagames.dofus.network.messages.game.friend
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.friend.IgnoredInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class IgnoredListMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5674;
       
      
      private var _isInitialized:Boolean = false;
      
      public var ignoredList:Vector.<IgnoredInformations>;
      
      private var _ignoredListtree:FuncTree;
      
      public function IgnoredListMessage()
      {
         this.ignoredList = new Vector.<IgnoredInformations>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5674;
      }
      
      public function initIgnoredListMessage(param1:Vector.<IgnoredInformations> = null) : IgnoredListMessage
      {
         this.ignoredList = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.ignoredList = new Vector.<IgnoredInformations>();
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
         this.serializeAs_IgnoredListMessage(param1);
      }
      
      public function serializeAs_IgnoredListMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.ignoredList.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.ignoredList.length)
         {
            param1.writeShort((this.ignoredList[_loc2_] as IgnoredInformations).getTypeId());
            (this.ignoredList[_loc2_] as IgnoredInformations).serialize(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_IgnoredListMessage(param1);
      }
      
      public function deserializeAs_IgnoredListMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc5_:IgnoredInformations = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readUnsignedShort();
            _loc5_ = ProtocolTypeManager.getInstance(IgnoredInformations,_loc4_);
            _loc5_.deserialize(param1);
            this.ignoredList.push(_loc5_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_IgnoredListMessage(param1);
      }
      
      public function deserializeAsyncAs_IgnoredListMessage(param1:FuncTree) : void
      {
         this._ignoredListtree = param1.addChild(this._ignoredListtreeFunc);
      }
      
      private function _ignoredListtreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._ignoredListtree.addChild(this._ignoredListFunc);
            _loc3_++;
         }
      }
      
      private function _ignoredListFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:IgnoredInformations = ProtocolTypeManager.getInstance(IgnoredInformations,_loc2_);
         _loc3_.deserialize(param1);
         this.ignoredList.push(_loc3_);
      }
   }
}
