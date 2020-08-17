package com.ankamagames.dofus.network.messages.authorized
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class ConsoleCommandsListMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6127;
       
      
      private var _isInitialized:Boolean = false;
      
      public var aliases:Vector.<String>;
      
      public var args:Vector.<String>;
      
      public var descriptions:Vector.<String>;
      
      private var _aliasestree:FuncTree;
      
      private var _argstree:FuncTree;
      
      private var _descriptionstree:FuncTree;
      
      public function ConsoleCommandsListMessage()
      {
         this.aliases = new Vector.<String>();
         this.args = new Vector.<String>();
         this.descriptions = new Vector.<String>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6127;
      }
      
      public function initConsoleCommandsListMessage(param1:Vector.<String> = null, param2:Vector.<String> = null, param3:Vector.<String> = null) : ConsoleCommandsListMessage
      {
         this.aliases = param1;
         this.args = param2;
         this.descriptions = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.aliases = new Vector.<String>();
         this.args = new Vector.<String>();
         this.descriptions = new Vector.<String>();
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
         this.serializeAs_ConsoleCommandsListMessage(param1);
      }
      
      public function serializeAs_ConsoleCommandsListMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.aliases.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.aliases.length)
         {
            param1.writeUTF(this.aliases[_loc2_]);
            _loc2_++;
         }
         param1.writeShort(this.args.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.args.length)
         {
            param1.writeUTF(this.args[_loc3_]);
            _loc3_++;
         }
         param1.writeShort(this.descriptions.length);
         var _loc4_:uint = 0;
         while(_loc4_ < this.descriptions.length)
         {
            param1.writeUTF(this.descriptions[_loc4_]);
            _loc4_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ConsoleCommandsListMessage(param1);
      }
      
      public function deserializeAs_ConsoleCommandsListMessage(param1:ICustomDataInput) : void
      {
         var _loc8_:String = null;
         var _loc9_:String = null;
         var _loc10_:String = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc8_ = param1.readUTF();
            this.aliases.push(_loc8_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc9_ = param1.readUTF();
            this.args.push(_loc9_);
            _loc5_++;
         }
         var _loc6_:uint = param1.readUnsignedShort();
         var _loc7_:uint = 0;
         while(_loc7_ < _loc6_)
         {
            _loc10_ = param1.readUTF();
            this.descriptions.push(_loc10_);
            _loc7_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ConsoleCommandsListMessage(param1);
      }
      
      public function deserializeAsyncAs_ConsoleCommandsListMessage(param1:FuncTree) : void
      {
         this._aliasestree = param1.addChild(this._aliasestreeFunc);
         this._argstree = param1.addChild(this._argstreeFunc);
         this._descriptionstree = param1.addChild(this._descriptionstreeFunc);
      }
      
      private function _aliasestreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._aliasestree.addChild(this._aliasesFunc);
            _loc3_++;
         }
      }
      
      private function _aliasesFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:String = param1.readUTF();
         this.aliases.push(_loc2_);
      }
      
      private function _argstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._argstree.addChild(this._argsFunc);
            _loc3_++;
         }
      }
      
      private function _argsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:String = param1.readUTF();
         this.args.push(_loc2_);
      }
      
      private function _descriptionstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._descriptionstree.addChild(this._descriptionsFunc);
            _loc3_++;
         }
      }
      
      private function _descriptionsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:String = param1.readUTF();
         this.descriptions.push(_loc2_);
      }
   }
}
